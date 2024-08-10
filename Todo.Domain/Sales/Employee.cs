using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Domain.Sales
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int user_auto_id { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public int role_id { get; set; }
        public Role role { get; set; }
        public ICollection<OrderBill>? orders { get; set; } = null;
        public Address addresses { get; set; } = null;

    }
}
