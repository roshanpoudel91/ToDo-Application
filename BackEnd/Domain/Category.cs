
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string date { get; set; }
    }
}
