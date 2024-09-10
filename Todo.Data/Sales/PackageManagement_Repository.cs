using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Transactions;
using Todo.Data.Infrastructure;
using Todo.Data.Queries.Sales;
using Todo.Data.SalesDto;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;
using Todo.Domain.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Todo.Data.Sales
{
    public class PackageManagement_Repository : IPackageManagement_Repository
    {
        DapperContext _context;
        public PackageManagement_Repository(DapperContext context) {
            _context = context;
        }

        public async Task<MessageStatus<long>> AddUser(User user)
        {
            var response = new MessageStatus<long>();

            try
            {
                using var connection = _context.CreateConnection();

                var checkExist = connection.GetAsync<User>(user.user_code);

                if (checkExist.Equals(null))
                {
                    var result = await connection.InsertAsync(user);
                    response.data = result;
                }
                response.success = true;
            }
            catch (Exception ex) {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }
        public async Task<MessageStatus<long>> AddAddress(Address address)
        {
            var response = new MessageStatus<long>();

            try
            {
                using var connection = _context.CreateConnection();

                var checkExist = connection.GetAsync<Address>(address.address_code);

                if (checkExist.Equals(null))
                {
                    var result = await connection.InsertAsync(address);
                    response.data = result;
                }
                response.success = true;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }
        public async Task<MessageStatus<long>> AddOrder(Order order)
        {
            var response = new MessageStatus<long>();

            try
            {
                using var connection = _context.CreateConnection();

                var result = await connection.InsertAsync(order);
                response.data = result;
                response.success = true;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }
        public async Task<MessageStatus<long>> AddTransport(Shipping trans)
        {
            var response = new MessageStatus<long>();

            try
            {
                using var connection = _context.CreateConnection();

                var result = await connection.InsertAsync(trans);
                response.data = result;
                response.success = true;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<MessageStatus<List<Order>>> GetOrderByUserId(int id)
        {
            var response = new MessageStatus<List<Order>>();
            string sql = @"
                         select
                            o.id,
                            order_code,
                            order_name,
                            amount,
                            o.other_fee,
                            postal_code,
                            payment_method,
                            creation_time,
                            customer_id,
                            customer_first_name,
                            customer_phone_number,
                            customer_province,
                            customer_city,
                            customer_ward,
                            customer_street,
                            shop_id,
                            shop_first_name,
                            shop_street,
                            shop_phone_number,
                            s.id,
                            ship_code,
                            ship_name,
                            product_type,
                            status,
                            problem_type,
                            hs_code,
                            delivery_service,
                            description,
                            number_of_print,
                            cod,
                            shipp_charges,
                            weight,
                            s.other_fee
                         from [Order] as o
                         join [Shipping] as s on o.id = s.order_id
                         where o.customer_id = '" + id + "'";
            try
            {
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Order, Shipping, Order>(sql,
                    (order, shipping) =>
                    {
                        order.Shipping = shipping;
                        return order;
                    }, splitOn: "id");

                response.data = result.ToList();
                response.success = true;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }



        // ĐỌC CODE Ở FUNCTION NÀY -------------------
        public async Task<MessageStatus<List<ShippingViewModel>>> GetAllPackage()
        {
            var response = new MessageStatus<List<ShippingViewModel>>();

            try
            {
                using var connection = _context.CreateConnection();

                var result = await connection.QueryAsync<ShippingViewModel>(Package.GetAllPackageInfo, commandType: CommandType.StoredProcedure);

                if (!result.Any())
                {
                    response.success = false;
                    response.message = "Don't have any data";
                }
                else
                {
                    response.success = true;
                    response.data = result.ToList();
                }

            } catch (Exception ex) {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }
        // ĐỌC CODE Ở FUNCTION NÀY -------------------



        public async Task<MessageStatus<string>> UploadExcel(UserDto customer, AddressDto address, OrderDto order, ShippingDto trans)
        {
            var response = new MessageStatus<string>();

            var userSQL = "select id from [User] where [user_code] = @code";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var checkUserExist = await connection.QuerySingleOrDefaultAsync<User>(userSQL, new { code = customer.user_code});

                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {

                        if (checkUserExist == null)
                        {
                            var executeUser = await connection.InsertAsync(customer, transaction);

                            address.user_id = executeUser;
                            await connection.InsertAsync(address, transaction);

                            order.customer_id = executeUser;
                            var executeOrder = await connection.InsertAsync(order, transaction);

                            trans.order_id = executeOrder;
                            await connection.InsertAsync(trans, transaction);
                        }else
                        {
                            order.customer_id = checkUserExist.id;
                            var executeOrder = await connection.InsertAsync(order, transaction);

                            trans.order_id = executeOrder;
                            await connection.InsertAsync(trans, transaction);
                        }

                        transaction.Commit();
                    }
                };
            }catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<MessageStatus<AggregateViewModel>> GetAggregatePackage()
        {
            var response = new MessageStatus<AggregateViewModel>();
            string procName = "SelectAggregateCod";
            try
            {
                using var connection = _context.CreateConnection();
                var result = await connection.QueryFirstOrDefaultAsync<AggregateViewModel>(procName, commandType: CommandType.StoredProcedure);
                response.success = true;
                response.data = result;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }
    }
}
