
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Domain.Sales
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<User>? User { get; set; }

    }
}
