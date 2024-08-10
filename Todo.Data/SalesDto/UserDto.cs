using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Sales;

namespace Todo.Data.SalesDto
{
    [Table("Employee")]
    public class UserDto
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int role_id { get; set; }

    }
}
