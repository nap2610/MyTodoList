using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.ViewModels
{
    public class UserViewModel
    {
        public int user_id { get; set; }
        public int order_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }
        public string phone_number { get; set; }
        public float amount { get; set; }
        public int count_order { get; set; }

    }
}
