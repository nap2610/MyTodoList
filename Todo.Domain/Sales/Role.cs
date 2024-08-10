using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Sales
{
    [Table("Role")]
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Employee>? employees { get; set; }

    }
}
