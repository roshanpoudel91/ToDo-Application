
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Priority")]
    public class Priority
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

    }
}
