using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Sales
{
    [Table("Shipping")]
    public class Shipping
    {
        [Key]
        public int id { get; set; }
        public string ship_code { get; set; }
        public string ship_name { get; set; }
        public string product_type { get; set; }
        public string status { get; set; }
        public string problem_type { get; set; }
        public string hs_code { get; set; }
        public string delivery_service { get; set; }
        public string description { get; set; }
        public int number_of_print { get; set; }
        public float cod { get; set; }
        public float shipp_charges { get; set; }
        public float weight { get; set; }
        public float other_fee { get; set; }
        public int order_id { get; set; }

        [ForeignKey("order_id")]
        public Order Order { get; set; }

    }
}
