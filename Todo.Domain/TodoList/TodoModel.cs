using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Domain.TodoList
{
    [Table("TodoList")]
    public class TodoModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string? desc { get; set; }

        /*        [Column(TypeName = "date")]*/
        public DateTime due_date { get; set; }

        public bool done { get; set; }
    }
}
