using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping.Identity
{
    public partial class UserMap:BaseMap<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.Property(u => u.UserName).IsRequired().HasMaxLength(256).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = false }));
            this.Property(u => u.Email).HasMaxLength(300);
            this.HasMany(u => u.Roles).WithRequired(ur => ur.User).HasForeignKey(ur => ur.UserId);
            this.HasMany(u => u.Logins).WithRequired(ul => ul.User).HasForeignKey(ul => ul.UserId);
            this.HasMany(u => u.Claims).WithRequired(uc => uc.User).HasForeignKey(uc => uc.UserId);
            this.HasOptional(u => u.CreateUser).WithMany().HasForeignKey(u => u.CreateBy).WillCascadeOnDelete(false);
            this.HasOptional(u => u.UpdateUser).WithMany().HasForeignKey(u => u.UpdateBy).WillCascadeOnDelete(false);

            this.Property(u => u.FullName).HasMaxLength(500);
        }
    }
}
