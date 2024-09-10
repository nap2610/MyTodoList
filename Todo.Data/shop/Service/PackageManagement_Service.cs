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
            return await _shippingRepository.GetAllShippingWithOrder(dsrequest, customerName, cod);
        }
    }
}
