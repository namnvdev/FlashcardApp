using FlashcardApp.Models;
using FlashcardApp.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlashcardApp.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<Member> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public DbInitializer(UserManager<Member> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        public void Initialize()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _dbContext.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            if (!_roleManager.RoleExistsAsync(Constants.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Constants.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.User)).GetAwaiter().GetResult();

                Member newUser = new Member
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FullName = "Admin",
                    Gender = "Nam",
                    Address = "Hoang Mai, HN",
                    City = "Ha Noi",
                    Country = "VN"
                };
               var result =  _userManager.CreateAsync(newUser, "Admin123").GetAwaiter().GetResult();
                
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(newUser, Constants.Admin).GetAwaiter().GetResult();
                    _userManager.AddToRoleAsync(newUser, Constants.User).GetAwaiter().GetResult();

                    
                    Console.WriteLine($"Admin user '{newUser.Email}' created and assigned to Admin role.");
                }
                else
                {
                    Console.WriteLine($"Failed to create admin '{newUser.Email}': {string.Join(", ", result.Errors)}");
                }
               
            }

            return;
        }
    }
}
