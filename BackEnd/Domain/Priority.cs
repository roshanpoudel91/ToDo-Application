
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Priority")]
    public class Priority
    {
        public int PriorityId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public virtual ICollection<ToDo>? Todos { get; set; }

    }
}
