using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Infrastructure;
using Todo.Data.SalesDto;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;
using Todo.Domain.ViewModels;

namespace Todo.Data.Sales
{
    public interface IPackageManagement_Repository
    {
        Task<MessageStatus<List<ShippingViewModel>>> GetAllPackage();
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        Task<MessageStatus<AggregateViewModel>> GetAggregatePackage();
        Task<MessageStatus<List<Order>>> GetOrderByUserId(int id);
        Task<MessageStatus<long>> AddTransport(Shipping trans);
        Task<MessageStatus<long>> AddOrder(Order order);
        Task<MessageStatus<long>> AddUser(User user);
        Task<MessageStatus<long>> AddAddress(Address address);
        Task<MessageStatus<string>> UploadExcel(UserDto customer, AddressDto address, OrderDto order, ShippingDto trans);
    }
}
