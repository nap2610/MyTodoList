using Kendo.Mvc.UI;
using Todo.Domain.BaseResponse;


namespace Todo.Data.shop.Repository
{
    public interface IShippingRepository
    {
        /// <summary>
        /// Lấy dữ liệu về đơn hàng: bảng Shipping left join bảng Order 
        /// </summary>
        /// <returns></returns>
        public Task<MessageStatus<DataSourceResult>> GetAllShippingWithOrder([DataSourceRequest] DataSourceRequest dsrequest, string customerName, string cod);
    }
}
