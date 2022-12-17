using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Core.Services.Admin;
using BurgerManiaApp.Core.Services.Deliverer;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.UnitTests
{
    public class UserServiceTests
    {
        private IRepository repo;
        private IUserService userService;
        private IRoleService roleService;
        private ApplicationDbContext context;

        //[SetUp]
        //public void Setup()
        //{
        //    var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        //        .UseInMemoryDatabase("BurgerDb")
        //        .EnableSensitiveDataLogging()
        //        .Options;

        //    context = new ApplicationDbContext(contextOptions);



        //    context.Database.EnsureDeletedAsync();
        //    context.Database.EnsureCreatedAsync();
        //}

        ////[Test]
        ////public async Task TestAllUsers()
        ////{
        ////    var repo = new Repository(context);
        ////    roleService = new RoleService()
        ////    userService = new UserService(repo);

        ////}


        //[TearDown]
        //public void TearDown()
        //{
        //    context.Dispose();
        //}
    }
}
