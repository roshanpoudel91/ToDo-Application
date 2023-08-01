using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;

namespace Domain
{
    [Table("ToDo")]
    public class ToDo
    {
        public int todoId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

      
        public int CategoryId { get; set; }
        public virtual Category? Categories { get; set; }

        public int PriorityId { get; set; }

        public virtual Priority? Priorities { get; set; }

        public string UserId { get; set; }

        public virtual User? Users { get; set; }

        public string Status { get; set; } = "created";

    }
}
