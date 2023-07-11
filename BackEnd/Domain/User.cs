using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser
    {
        public User()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ToDo>? Todos { get; set; }

    }

}
