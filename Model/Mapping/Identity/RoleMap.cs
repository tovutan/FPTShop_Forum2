using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping.Identity
{
    public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Role");
            this.HasKey(r => r.Id).Property(r=>r.Id).HasColumnType("Int").IsRequired();
            this.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(300)
                 .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
            this.HasMany(r => r.Users).WithRequired(ur => ur.Role).HasForeignKey(ur => ur.RoleId);

        }
    }
}
