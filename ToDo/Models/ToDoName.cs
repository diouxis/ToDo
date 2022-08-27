using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoName
    {
        public string? DefaultName { get; set; }

        public static ToDoName CLName => new ToDoName()
        {
            DefaultName ="CL"
        };
    }
}
