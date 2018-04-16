using Microsoft.AspNet.Identity.EntityFramework;
using Model.Entities;
using Model.Entities.Identity;
using Model.Mapping.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class ApplicationDbContext:IdentityDbContext<User,Role,string,UserLogin,UserRole,UserClaim>
    {
        public ApplicationDbContext() : base("FPTShop_Forum2")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
               
        }
    }
}
