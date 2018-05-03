using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class TagMap:BaseMap<Tag>
    {
        public TagMap()
        {
            this.ToTable("Tag");

            this.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.Property(r => r.URL)
               .IsRequired()
               .HasMaxLength(300)
               .IsUnicode(false)
               .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.HasRequired(e => e.CreateUser).WithMany().HasForeignKey(e => e.CreateBy).WillCascadeOnDelete(false);
            this.HasOptional(e => e.UpdateUser).WithMany().HasForeignKey(e => e.UpdateBy).WillCascadeOnDelete(false);
        }
    }
}
