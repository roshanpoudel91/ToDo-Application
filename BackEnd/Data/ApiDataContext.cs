using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Shared.Constants;

namespace Data
{

    public class ApiDataContext : IdentityDbContext<User, Domain.Role, string>
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding a  'Admin' role to AspNetRoles table
            modelBuilder.Entity<Role>().HasData(new Role { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = RoleNames.Admin, NormalizedName = RoleNames.Admin.ToUpper(), Description = $"Capstone Todos {RoleNames.Admin}" });

            //Seeding a  'User' role to AspNetRoles table
            modelBuilder.Entity<Role>().HasData(new Role { Id = "65764886-4f92-4c2d-b426-a0fe8b26e855", Name = RoleNames.User, NormalizedName = RoleNames.User.ToUpper(), Description = $"Capstone Todos {RoleNames.User}" });

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<User>();

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin@capstone.com",
                    Email = "admin@capstone.com",
                    NormalizedUserName = "admin@capstone.com",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                    FirstName = "Admin",
                    LastName = "Capstone",
                    PhoneNumber = "17809091212",
                    EmailConfirmed = true,
                    NormalizedEmail = "admin@capstone.com"
                }
            );

            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );


        }
    }
}
