//#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate  { get; set; }
        public DateTime? FinishDate { get; set; }
    }

    public class TODoIndex
    {
        public string NameA { get; set; } = "A";
        public string NameB { get; set; } = "B";
        public string NameC { get; set; } = "C";
    }
}
