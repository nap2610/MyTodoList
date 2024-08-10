
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Domain.Sales
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int address_auto_id { get; set; }
        public string address_id { get; set; }
        public string? province { get; set; }
        public string? city { get; set; }
        public string ward { get; set; }
        public string street { get; set; }
        public string user_id { get; set; }
        public Employee user { get; set; }
    }
}
