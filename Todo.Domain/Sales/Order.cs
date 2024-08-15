using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Sales
{
    [Table("[Order]")]
    public class Order
    {
        [Key]
        public int id { get; set; }
        public string order_code { get; set; }
        public string order_name { get; set; }
        public float amount { get; set; }
        public float other_fee { get; set; }
        public string customer_first_name { get; set; }
        public string customer_phone_number { get; set; }
        public string customer_city { get; set; }
        public string customer_province { get; set; }
        public string customer_ward { get; set; }
        public string customer_street { get; set; }
        public string shop_first_name { get; set; }
        public string shop_phone_number { get; set; }
        public string shop_city { get; set; }
        public string shop_province { get; set; }
        public string shop_ward { get; set; }
        public string shop_street { get; set; }
        public string postal_code { get; set; }
        public string payment_method { get; set; }
        public DateTime creation_time { get; set; }
        public int customer_id { get; set; }
        public int shop_id { get; set; }
        public int staff_id { get; set; }

        public Shipping Shipping { get; set; }

        [ForeignKey("customer_id")]
        public User Customer { get; set; }

        [ForeignKey("shop_id")]
        public User Shop { get; set; }

        [ForeignKey("staff_id")]
        public User Staff { get; set; }
    }
}
