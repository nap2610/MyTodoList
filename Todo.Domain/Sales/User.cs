using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Domain.Sales
{
    [Table("[User]")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public int active { get; set; }
        public DateTime created_at { get; set; }
        public int role_id { get; set; }

        public Role Role { get; set; }
        public ICollection<Order> Order { get; set; }
        public Address? Address { get; set; }

    }
}
