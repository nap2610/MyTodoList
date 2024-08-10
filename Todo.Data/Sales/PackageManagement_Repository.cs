using Dapper;
using Dapper.Contrib.Extensions;
using System.Net;
using System.Transactions;
using Todo.Data.Infrastructure;
using Todo.Data.Queries.Sales;
using Todo.Data.SalesDto;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Todo.Data.Sales
{
    public class PackageManagement_Repository : IPackageManagement_Repository
    {
        DapperContext _context;
        public PackageManagement_Repository(DapperContext context) {
            _context = context;
        }

        public async Task<MessageStatus<long>> AddUser(Employee user)
        {
            var response = new MessageStatus<long>();

            try
            {
                using var connection = _context.CreateConnection();

                var checkExist = connection.GetAsync<Employee>(user.user_id);

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

                var checkExist = connection.GetAsync<Address>(address.address_id);

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
        public async Task<MessageStatus<long>> AddOrder(OrderBill order)
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
        public async Task<MessageStatus<long>> AddTransport(TransportBill trans)
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

        public async Task<MessageStatus<List<TransportBill>>> GetAllPackage()
        {
            var response = new MessageStatus<List<TransportBill>>();

            try
            {
                using var connection = _context.CreateConnection();

                var result = await connection.QueryAsync<TransportBill, OrderBill, Employee, Employee, Address, Address, TransportBill>
                    (Package.GetAllPackageInfo,
                    (trans, order, emp1, emp2, adr1, adr2) =>
                    {
                        trans.orders = order;
                        order.customer = emp1;
                        order.shop = emp2;
                        emp1.addresses = adr1;
                        emp2.addresses = adr2;
                        return trans;
                    },
                    splitOn: "order_id, user_auto_id, user_auto_id, address_auto_id, address_auto_id");

                /*                var result = await connection.QueryAsync<TransportBill>(sql);
                                Console.WriteLine("Result:  " + result);*/

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
                //set success true khi có exception
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<MessageStatus<long>> UploadExcel(UserDto customer, AddressDto address, OrderDto order, TransportDto trans)
        {
            var response = new MessageStatus<long>();

            var userSQL = "select user_auto_id from [Employee] where [user_id] = @Id";

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var checkUserExist = await connection.QuerySingleOrDefaultAsync<Employee>(userSQL, new { Id = customer.user_id});

                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {

                        if (checkUserExist == null)
                        {
                            var executeUser = await connection.InsertAsync(customer, transaction);

                            address.user_id = executeUser;
                            await connection.InsertAsync(address, transaction);

                            order.customer_id = executeUser;
                            await connection.InsertAsync(order, transaction);

                            await connection.InsertAsync(trans, transaction);
                        }else
                        {
                            order.customer_id = checkUserExist.user_auto_id;
                            await connection.InsertAsync(order, transaction);

                            await connection.InsertAsync(trans, transaction);
                        }

                        transaction.Commit();
                    }
                    response.success = true;
                };
            }catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }
    }
}
