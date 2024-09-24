using Kendo.Mvc.UI;
using Todo.Domain.BaseResponse;
using Todo.Domain.ViewModels;


namespace Todo.Data.shop.Repository
{
    public interface IShippingRepository
    {
        /// <summary>
        /// Lấy dữ liệu về đơn hàng: bảng Shipping left join bảng Order 
        /// </summary>
        /// <returns></returns>
        public Task<MessageStatus<IEnumerable<ShippingViewModel>>> GetAllShippingWithOrder(int pageNumber, int pageSize, string customerName, string cod);

        public Task<MessageStatus<int>> GetShippingCount();

        public Task<MessageStatus<AggregateViewModel>> GetAggregateShipping();
    }
}
