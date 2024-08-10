using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Sales
{
    [Table("Transport_Bill")]
    public class TransportBill
    {
        [Key]
        public string transport_id { get; set; }
        public string transport_name { get; set; }
        public string type { get; set; }
        public string acknowledge_receipt { get; set; }
        public string status { get; set; }
        public string problem_type { get; set; }
        public string payment_method { get; set; }
        public string postal_code { get; set; }
        public string delivery_service { get; set; }
        public string hs_code { get; set; }
        public string? description { get; set; }
        public int number_of_print { get; set; }
        public float weight { get; set; }
        public float other_fee { get; set; }
        public float shipping_charges { get; set; }
        public float cod { get; set; }
        public string order_id { get; set; }
        public OrderBill orders { get; set; }

    }
}
