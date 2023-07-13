using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
    [Table("ToDo")]
    public class ToDo
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Categories { get; set; }

        public int PriorityId { get; set; }

        public virtual Priority? Priorities { get; set; }

        public string UserId { get; set; }

        public virtual User? Users { get; set; }

    }
}
