using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Todo.Domain.Sales;

namespace Todo.Data.SalesDto
{
    [Table("Address")]
    public class AddressDto
    {
        public string address_code { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string ward { get; set; }
        public string street { get; set; }
        public string phone_number { get; set; }
        public string postal_code { get; set; }
        public int user_id { get; set; }
    }
}
