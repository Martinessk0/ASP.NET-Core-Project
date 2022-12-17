using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Core.Services.Admin;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using BurgerManiaApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.UnitTests
{
    public class RoleServiceTests
    {
        private IRepository repo;
        private IRoleService roleService;
        private ApplicationDbContext context;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("BurgerDb")
                .EnableSensitiveDataLogging()
                .Options;

            context = new ApplicationDbContext(contextOptions);



            context.Database.EnsureDeletedAsync();
            context.Database.EnsureCreatedAsync();
        }

        //[Test]
        //public async Task TestAddRole()
        //{
        //    var repo = new Repository(context);
        //    userManager = new UserManager<User>();
        //    roleManager = new RoleManager<IdentityRole>();
        //    roleService = new UserService(roleManager, userManager);

        //}


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
