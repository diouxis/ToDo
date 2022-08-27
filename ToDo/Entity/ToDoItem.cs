using System;
using System.Collections.Generic;

namespace ToDo.Entity
{
    public partial class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int Order { get; set; }
    }
}
