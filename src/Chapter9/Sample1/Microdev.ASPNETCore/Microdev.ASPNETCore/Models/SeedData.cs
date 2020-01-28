using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Microdev.ASPNETCore.Models
{
    public class SeedData
    {
        private readonly MicrodevDbContext _ctx;
        private readonly UserManager<User> _userManager;

        public SeedData(MicrodevDbContext ctx,
                    UserManager<User> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("Info@Microdev.com");

            if (user == null)
            {
                user = new User()
                {
                    FirstName = "Jennifer",
                    LastName = "Lerman",
                    UserName = "Info@Microdev.com",
                    Email = "Info@Microdev.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }

        }
    }
}
