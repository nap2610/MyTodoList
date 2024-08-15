
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Domain.Sales
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int id { get; set; }
        public string address_code { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string ward { get; set; }
        public string street { get; set; }
        public string phone_number { get; set; }
        public string postal_code { get; set; }
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }
    }
}
