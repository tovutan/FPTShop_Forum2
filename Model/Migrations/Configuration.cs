namespace Model.Migrations
{
    using Entities.Identity;
    using Microsoft.AspNet.Identity;
    using Store;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.Services.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Model.Services.ApplicationDbContext";
        }

        protected override void Seed(Model.Services.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var user = new User()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                CreateDate = DateTime.Now,
                FullName = "Administrator",
                AuthorName = "Administrator"
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                context.Roles.AddOrUpdate(
                    new Role(RoleType.Admin),
                    new Role(RoleType.Manager),
                    new Role(RoleType.User)
                    );

                var roleManager = new RoleManager<Role>(new RoleStore(context));
                var UserManager = new UserManager<User>(new UserStore(context));

                string userPWD = @"Admin123!@#";
                var chkUser = UserManager.Create(user, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, RoleType.Admin);
                }
            }

        }
    }
}
