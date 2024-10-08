﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Sales;

namespace Todo.Data.SalesDto
{
    [Table("[User]")]
    public class UserDto
    {
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public int active { get; set; }
        public DateTime? created_at { get; set; }
        public int role_id { get; set; }

    }
}
