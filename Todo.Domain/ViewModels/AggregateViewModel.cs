using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.ViewModels
{
    public class AggregateViewModel
    {
        public int countElement { get; set; }
        public decimal sumElement { get; set; }
        public float averageElement { get; set; }
        public float minElement { get; set; }
        public float maxElement { get; set; }
    }
}
