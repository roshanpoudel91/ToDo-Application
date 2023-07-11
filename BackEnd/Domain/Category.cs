
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Category")]
    public class Category
    {
        public int CategoryId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string date { get; set; }

        public virtual ICollection<ToDo>? Todos { get; set; }
    }
}
