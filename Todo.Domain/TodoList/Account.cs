
using System.ComponentModel.DataAnnotations.Schema;


namespace Todo.Domain.TodoList
{
    [Table("Account")]
    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
