using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Sales
{
    [Table("Order_Bill")]
    public class OrderBill
    {
        [Key]
        public string order_id { get; set; }
        public DateTime creation_time { get; set; }

        public int customer_id { get; set; }
        [ForeignKey("customer_id")]
        public Employee customer { get; set; }

        public int shop_id { get; set; }
        [ForeignKey("shop_id")]
        public Employee shop { get; set; }
    }
}
