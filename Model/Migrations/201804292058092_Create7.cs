namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Posts", newName: "Post");
            RenameTable(name: "dbo.Tags", newName: "Tag");
            RenameTable(name: "dbo.Logs", newName: "Log");
            RenameTable(name: "dbo.TagPosts", newName: "Post_Tag_Map");
            DropIndex("dbo.Tag", new[] { "CreateUser_Id" });
            DropIndex("dbo.Log", new[] { "CreateUser_Id" });
            DropColumn("dbo.Category", "ParentID");
            DropColumn("dbo.Post", "CreateBy");
            DropColumn("dbo.Post", "UpdateBy");
            DropColumn("dbo.Tag", "CreateBy");
            DropColumn("dbo.Tag", "UpdateBy");
            DropColumn("dbo.Log", "CreateBy");
            RenameColumn(table: "dbo.Category", name: "ParentCategory_ID", newName: "ParentID");
            RenameColumn(table: "dbo.Post", name: "CreateUser_Id", newName: "CreateBy");
            RenameColumn(table: "dbo.Post_Tag_Map", name: "Tag_Id", newName: "TagID");
            RenameColumn(table: "dbo.Post_Tag_Map", name: "Post_ID", newName: "PostID");
            RenameColumn(table: "dbo.Post", name: "UpdateUser_Id", newName: "UpdateBy");
            RenameColumn(table: "dbo.Tag", name: "CreateUser_Id", newName: "CreateBy");
            RenameColumn(table: "dbo.Tag", name: "UpdateUser_Id", newName: "UpdateBy");
            RenameColumn(table: "dbo.Log", name: "CreateUser_Id", newName: "CreateBy");
            RenameIndex(table: "dbo.Category", name: "IX_ParentCategory_ID", newName: "IX_ParentID");
            RenameIndex(table: "dbo.Post", name: "IX_CreateUser_Id", newName: "IX_CreateBy");
            RenameIndex(table: "dbo.Post", name: "IX_UpdateUser_Id", newName: "IX_UpdateBy");
            RenameIndex(table: "dbo.Tag", name: "IX_UpdateUser_Id", newName: "IX_UpdateBy");
            RenameIndex(table: "dbo.Post_Tag_Map", name: "IX_Post_ID", newName: "IX_PostID");
            RenameIndex(table: "dbo.Post_Tag_Map", name: "IX_Tag_Id", newName: "IX_TagID");
            DropPrimaryKey("dbo.Post_Tag_Map");
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Category", "UrlSlug", c => c.String(nullable: false, maxLength: 450, unicode: false));
            AlterColumn("dbo.Category", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "UrlSlug", c => c.String(maxLength: 450));
            AlterColumn("dbo.Tag", "Name", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Tag", "URL", c => c.String(nullable: false, maxLength: 300, unicode: false));
            AlterColumn("dbo.Tag", "CreateBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Tag", "CreateBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Log", "CreateBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Log", "CreateBy", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Post_Tag_Map", new[] { "PostID", "TagID" });
            CreateIndex("dbo.Category", "Name");
            CreateIndex("dbo.Category", "UrlSlug");
            CreateIndex("dbo.Post", "UrlSlug");
            CreateIndex("dbo.Tag", "Name");
            CreateIndex("dbo.Tag", "URL");
            CreateIndex("dbo.Tag", "CreateBy");
            CreateIndex("dbo.Log", "CreateBy");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Log", new[] { "CreateBy" });
            DropIndex("dbo.Tag", new[] { "CreateBy" });
            DropIndex("dbo.Tag", new[] { "URL" });
            DropIndex("dbo.Tag", new[] { "Name" });
            DropIndex("dbo.Post", new[] { "UrlSlug" });
            DropIndex("dbo.Category", new[] { "UrlSlug" });
            DropIndex("dbo.Category", new[] { "Name" });
            DropPrimaryKey("dbo.Post_Tag_Map");
            AlterColumn("dbo.Log", "CreateBy", c => c.Int());
            AlterColumn("dbo.Log", "CreateBy", c => c.Int());
            AlterColumn("dbo.Tag", "CreateBy", c => c.Int());
            AlterColumn("dbo.Tag", "CreateBy", c => c.Int());
            AlterColumn("dbo.Tag", "URL", c => c.String());
            AlterColumn("dbo.Tag", "Name", c => c.String());
            AlterColumn("dbo.Post", "UrlSlug", c => c.String());
            AlterColumn("dbo.Post", "Title", c => c.String());
            AlterColumn("dbo.Category", "Description", c => c.String());
            AlterColumn("dbo.Category", "UrlSlug", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String());
            AddPrimaryKey("dbo.Post_Tag_Map", new[] { "Tag_Id", "Post_ID" });
            RenameIndex(table: "dbo.Post_Tag_Map", name: "IX_TagID", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.Post_Tag_Map", name: "IX_PostID", newName: "IX_Post_ID");
            RenameIndex(table: "dbo.Tag", name: "IX_UpdateBy", newName: "IX_UpdateUser_Id");
            RenameIndex(table: "dbo.Post", name: "IX_UpdateBy", newName: "IX_UpdateUser_Id");
            RenameIndex(table: "dbo.Post", name: "IX_CreateBy", newName: "IX_CreateUser_Id");
            RenameIndex(table: "dbo.Category", name: "IX_ParentID", newName: "IX_ParentCategory_ID");
            RenameColumn(table: "dbo.Log", name: "CreateBy", newName: "CreateUser_Id");
            RenameColumn(table: "dbo.Tag", name: "UpdateBy", newName: "UpdateUser_Id");
            RenameColumn(table: "dbo.Tag", name: "CreateBy", newName: "CreateUser_Id");
            RenameColumn(table: "dbo.Post", name: "UpdateBy", newName: "UpdateUser_Id");
            RenameColumn(table: "dbo.Post_Tag_Map", name: "PostID", newName: "Post_ID");
            RenameColumn(table: "dbo.Post_Tag_Map", name: "TagID", newName: "Tag_Id");
            RenameColumn(table: "dbo.Post", name: "CreateBy", newName: "CreateUser_Id");
            RenameColumn(table: "dbo.Category", name: "ParentID", newName: "ParentCategory_ID");
            AddColumn("dbo.Log", "CreateBy", c => c.Int());
            AddColumn("dbo.Tag", "UpdateBy", c => c.Int());
            AddColumn("dbo.Tag", "CreateBy", c => c.Int());
            AddColumn("dbo.Post", "UpdateBy", c => c.Int());
            AddColumn("dbo.Post", "CreateBy", c => c.Int());
            AddColumn("dbo.Category", "ParentID", c => c.Int());
            CreateIndex("dbo.Log", "CreateUser_Id");
            CreateIndex("dbo.Tag", "CreateUser_Id");
            RenameTable(name: "dbo.Post_Tag_Map", newName: "TagPosts");
            RenameTable(name: "dbo.Log", newName: "Logs");
            RenameTable(name: "dbo.Tag", newName: "Tags");
            RenameTable(name: "dbo.Post", newName: "Posts");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
