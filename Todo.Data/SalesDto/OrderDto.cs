using Dapper.Contrib.Extensions;
using Todo.Domain.Sales;

namespace Todo.Data.SalesDto
{
    [Table("Order_Bill")]
    public class OrderDto
    {
        public string order_id { get; set; }
        public DateTime creation_time { get; set; }
        public int customer_id { get; set; }
        public int shop_id { get; set; }
    }
}
