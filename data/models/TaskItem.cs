using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApi.models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Category { get; set; }
    }
}
