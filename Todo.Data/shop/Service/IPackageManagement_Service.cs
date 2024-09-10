using Kendo.Mvc.UI;
using Todo.Domain.BaseResponse;

namespace Todo.Data.shop.Service
{
    public interface IPackageManagement_Service
    {
        /// <summary>
        /// Lấy dữ liệu về đơn hàng: bảng Shipping left join bảng Order (Gọi từ IShippingRepository)
        /// </summary>
        /// <param name="dsrequest"></param>
        /// <param name="customerName"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        public Task<MessageStatus<DataSourceResult>> GetAllPackage([DataSourceRequest] DataSourceRequest dsrequest, string customerName, string cod);
    }
}
