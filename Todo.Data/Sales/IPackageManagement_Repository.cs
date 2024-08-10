using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Infrastructure;
using Todo.Data.SalesDto;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;

namespace Todo.Data.Sales
{
    public interface IPackageManagement_Repository
    {
        Task<MessageStatus<List<TransportBill>>> GetAllPackage();

        Task<MessageStatus<long>> AddTransport(TransportBill trans);
        Task<MessageStatus<long>> AddOrder(OrderBill order);
        Task<MessageStatus<long>> AddUser(Employee user);
        Task<MessageStatus<long>> AddAddress(Address address);
        Task<MessageStatus<long>> UploadExcel(UserDto customer, AddressDto address, OrderDto order, TransportDto trans);
    }
}
