using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.ViewModels
{
    public class ShippingViewModel
    {
        public int ship_id { get; set; }
        public int order_id { get; set; }
        public string ship_code { get; set; }
        public string ship_name { get; set; }
        public string status { get; set; }
        public string problem_type { get; set; }
        public string hs_code { get; set; }
        public string delivery_service { get; set; }
        public string description { get; set; }
        public float ship_other_fee { get; set; }
        public float order_other_fee { get; set; }
        public float cod { get; set; }
        public float amount { get; set; }
        public float shipp_charges { get; set; }
        public float weight { get; set; }
        public int number_of_print { get; set; }
        public string order_name { get; set; }
        public string order_code { get; set; }
        public string postal_code { get; set; }
        public string payment_method { get; set; }
        public string creation_time { get; set; }
        public int customer_id { get; set; }
        public int shop_id { get; set; }
        public string customer_first_name { get; set; }
        public string customer_phone_number { get; set; }
        public string customer_province { get; set; }
        public string customer_city { get; set; }
        public string customer_ward { get; set; }
        public string customer_street { get; set; }
        public string shop_first_name { get; set; }
        public string shop_street { get; set; }
        public string shop_phone_number { get; set; }

    }
}
