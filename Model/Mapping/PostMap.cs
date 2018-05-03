﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Mapping
{
    public class PostMap:BaseMap<Post>
    {
        public PostMap()
        {
            this.ToTable("Post");

            this.Property(r => r.Title)
                .IsRequired()
                .IsMaxLength();

            this.Property(r => r.UrlSlug)              
                .HasMaxLength(450)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = false }));

            this.Property(r => r.Description)
                .IsMaxLength();

            // quan hệ n-n Categories
            //this.HasMany(u => u.Categories).WithRequired(u => u.Posts)
            //    .Map(m => m.ToTable("Post_Category_Map").MapLeftKey("PostID").MapRightKey("CatID"));

            // quan hệ n-1 với Categories
            this.HasRequired(u => u.Category).WithMany(u => u.Posts).HasForeignKey(u=>u.CategoryID);

            this.HasMany(u => u.Tags).WithMany(u => u.Posts)
                .Map(m => m.ToTable("Post_Tag_Map").MapLeftKey("PostID").MapRightKey("TagID"));


            this.Property(e => e.DateCreate).IsRequired();

            //this.HasRequired(e => e.CreateUser).WithMany().HasForeignKey(e => e.CreateBy).WillCascadeOnDelete(false);
            this.HasOptional(e => e.CreateUser).WithMany().HasForeignKey(e => e.CreateBy).WillCascadeOnDelete(false);
            this.HasOptional(e => e.UpdateUser).WithMany().HasForeignKey(e => e.UpdateBy).WillCascadeOnDelete(false);

            // Tạm thời chưa dùng đến nên bỏ
            this.HasOptional(e => e.LastPostUser).WithMany().HasForeignKey(e => e.LastPostUserID).WillCascadeOnDelete(false);


        }
        
    }
}
