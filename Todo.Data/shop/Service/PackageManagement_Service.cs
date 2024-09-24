using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Todo.Data.shop.Repository;
using Todo.Domain.BaseResponse;

namespace Todo.Data.shop.Service
{
    public class PackageManagement_Service : IPackageManagement_Service
    {
        IShippingRepository _shippingRepository;
        public PackageManagement_Service(IShippingRepository shippingRepository) 
        {
            _shippingRepository = shippingRepository;
        }
        public async Task<MessageStatus<DataSourceResult>> GetAllPackage([DataSourceRequest] DataSourceRequest dsrequest, string customerName, string cod)
        {

            if (!String.IsNullOrEmpty(customerName) || !String.IsNullOrEmpty(cod))
            {
                var packageFilter = await _shippingRepository.GetAllShippingWithOrder(dsrequest.Page, dsrequest.PageSize, customerName, cod);

                if (packageFilter.success) {
                    dsrequest.Page = 1;
                    return new MessageStatus<DataSourceResult>()
                    {
                        data = new DataSourceResult()
                        {
                            Data = packageFilter.data,
                            Total = (await _shippingRepository.GetShippingCount()).data,
                        },
                    };
                }
                return new MessageStatus<DataSourceResult>()
                {
                    data = new DataSourceResult
                    {
                        Errors = new[] { packageFilter.message },
                    },
                };
            }

            var packages = await _shippingRepository.GetAllShippingWithOrder(dsrequest.Page, dsrequest.PageSize, customerName, cod);

            if (packages.success){
                return new MessageStatus<DataSourceResult>()
                {
                    data = new DataSourceResult()
                    {
                        Data = packages.data,
                        Total = (await _shippingRepository.GetShippingCount()).data,
                    },
                };
            }
            return new MessageStatus<DataSourceResult>()
            {
                data = new DataSourceResult
                {
                    Errors = new[] { packages.message },
                },
            };
        }
    }
}
