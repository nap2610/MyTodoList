using Dapper;
using Kendo.Mvc.UI;
using SystemData = System.Data;
using Todo.Data.Infrastructure;
using Todo.Data.Queries.Sales;
using Todo.Domain.BaseResponse;
using Todo.Domain.ViewModels;
using Kendo.Mvc.Extensions;
using Azure.Core;

namespace Todo.Data.shop.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        DapperContext _context;
        public ShippingRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<MessageStatus<AggregateViewModel>> GetAggregateShipping()
        {
            string procName = "SelectAggregateCod";
            using var connection = _context.CreateConnection();

            return new MessageStatus<AggregateViewModel>()
            {
                success = true,
                data = await connection.QueryFirstOrDefaultAsync<AggregateViewModel>(procName, commandType: SystemData.CommandType.StoredProcedure),
            };
        }

        public async Task<MessageStatus<IEnumerable<ShippingViewModel>>> GetAllShippingWithOrder(int pageNumber, int pageSize, string customerName, string cod)
        {
            using var connection = _context.CreateConnection();

            var packages = await connection.QueryAsync<ShippingViewModel>(Package.GetAllPackageInfo, 
                new { PageNumber = pageNumber, PageSize = pageSize, CustomerName = customerName, Cod = cod }, commandType: SystemData.CommandType.StoredProcedure);

            if (!packages.Any())
                return new MessageStatus<IEnumerable<ShippingViewModel>>()
                {
                    success = false,
                    message = "Data is empty",
                };

            return new MessageStatus<IEnumerable<ShippingViewModel>>()
            {
                success = true,
                data = packages,
            };
        }

        public async Task<MessageStatus<int>> GetShippingCount()
        {
            using var connection = _context.CreateConnection();
            string sql = "SELECT COUNT(*) FROM [SHIPPING]";

            return new MessageStatus<int>() { 
                success = true,
                data = await connection.ExecuteScalarAsync<int>(sql),
            };
        }
    }

}
