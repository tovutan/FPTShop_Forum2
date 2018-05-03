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
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            //this.HasKey(d => d.ID);

            this.Property(r => r.UrlSlug)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(400)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.Property(r => r.Description)
                .IsRequired()
                .IsMaxLength();

            //this.HasMany(c => c.ChildCategory)
            //    .WithOptional(c => c.ParentCategory)
            //    .HasForeignKey(c => c.ParentID);

            this.Property(c => c.IsDelete).IsRequired();

            //this.Property(c => c.DateCreated).IsRequired();

            //this.HasRequired(e => e.CreateUser).WithMany().HasForeignKey(c => c.CreateBy).WillCascadeOnDelete(false);
            //this.HasOptional(e => e.ModifiedUser).WithMany().HasForeignKey(e => e.ModifiedBy).WillCascadeOnDelete(false);


            //// quan hệ n-n với bảng Post
            //this.HasMany(c=>c.Posts).WithMany(c=>c.Categories)
            //    .Map(m => m.ToTable("Post_Category_Map"));

            //// quan hệ n-n với bảng Tag có khóa là ID
            //this.HasKey(p => p.ID)
            //    .Map(m => m.ToTable("Category_Tag_Map"));
        }
    }
}
