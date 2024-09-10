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

        public async Task<MessageStatus<DataSourceResult>> GetAllShippingWithOrder([DataSourceRequest] DataSourceRequest dsrequest, string customerName, string cod)
        {
            var response = new MessageStatus<DataSourceResult>();

            using var connection = _context.CreateConnection();

            var packages = await connection.QueryAsync<ShippingViewModel>(Package.GetAllPackageInfo, commandType: SystemData.CommandType.StoredProcedure);

            if (!packages.Any())
                return new MessageStatus<DataSourceResult>() { success = false, message = "Don't have any data" };

            if (!string.IsNullOrEmpty(customerName))
            {
                dsrequest.Page = 1;
                packages = packages.Where(o => o.customer_first_name.Contains(customerName));
            }

            if (!string.IsNullOrEmpty(cod))
            {
                dsrequest.Page = 1;
                packages = packages.Where(o => o.cod.Equals(float.Parse(cod)));
            }

            response.success = true;
            response.data = packages.ToDataSourceResult(dsrequest);
            return response;
            //if (!packages.Any())
            //{
            //    response.success = false;
            //    response.message = "Don't have any data";
            //    response.data = new DataSourceResult
            //    {
            //        Errors = new[] { response.message },
            //    };
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(customerName))
            //    {
            //        dsrequest.Page = 1;
            //        packages = packages.Where(o => o.customer_first_name.Contains(customerName));
            //    }

            //    if (!string.IsNullOrEmpty(cod))
            //    {
            //        dsrequest.Page = 1;
            //        packages = packages.Where(o => o.cod.Equals(float.Parse(cod)));
            //    }

            //    response.success = true;
            //    response.data = packages.ToDataSourceResult(dsrequest);
            //}

            //return response;
        }
    }

}
