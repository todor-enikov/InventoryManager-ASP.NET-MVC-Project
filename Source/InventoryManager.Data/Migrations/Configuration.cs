namespace InventoryManager.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<InventoryManager.Data.InventoryManagerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InventoryManagerDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdmin(context);
        }

        private void SeedRoles(InventoryManagerDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = ApplicationConstants.AdminRole };
                roleManager.Create(adminRole);

                var userRole = new IdentityRole { Name = ApplicationConstants.UserRole };
                roleManager.Create(userRole);

                context.SaveChanges();
            }
        }

        private void SeedAdmin(InventoryManagerDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                var defaultAdmin = new User()
                {
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    UserName = "Administrator",
                    Email = "Admin@istrator.bg"
                };

                userManager.Create(defaultAdmin, "123456");
                userManager.AddToRole(defaultAdmin.Id, ApplicationConstants.AdminRole);
                context.SaveChanges();
            }
        }
    }
}
