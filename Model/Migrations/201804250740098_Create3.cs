namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User");
            DropIndex("dbo.Categories", new[] { "CreateUser_Id" });
            DropIndex("dbo.Categories", new[] { "ModifiedUser_Id" });
            RenameColumn(table: "dbo.Posts", name: "LastModifiedUser_Id", newName: "CreateUser_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_LastModifiedUser_Id", newName: "IX_CreateUser_Id");
            AddColumn("dbo.Categories", "UpdateBy", c => c.String());
            AddColumn("dbo.Posts", "CreateBy", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "UpdateBy", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "UpdateUser_Id", c => c.Int());
            AlterColumn("dbo.Categories", "CreateBy", c => c.String());
            CreateIndex("dbo.Posts", "UpdateUser_Id");
            AddForeignKey("dbo.Posts", "UpdateUser_Id", "dbo.User", "Id");
            DropColumn("dbo.Categories", "ModifiedBy");
            DropColumn("dbo.Categories", "CreateUser_Id");
            DropColumn("dbo.Categories", "ModifiedUser_Id");
            DropColumn("dbo.Posts", "UserID");
            DropColumn("dbo.Posts", "LastUserModifiedID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "LastUserModifiedID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "UserID", c => c.Int());
            AddColumn("dbo.Categories", "ModifiedUser_Id", c => c.Int());
            AddColumn("dbo.Categories", "CreateUser_Id", c => c.Int());
            AddColumn("dbo.Categories", "ModifiedBy", c => c.Int());
            DropForeignKey("dbo.Posts", "UpdateUser_Id", "dbo.User");
            DropIndex("dbo.Posts", new[] { "UpdateUser_Id" });
            AlterColumn("dbo.Categories", "CreateBy", c => c.Int());
            DropColumn("dbo.Posts", "UpdateUser_Id");
            DropColumn("dbo.Posts", "UpdateBy");
            DropColumn("dbo.Posts", "CreateBy");
            DropColumn("dbo.Categories", "UpdateBy");
            RenameIndex(table: "dbo.Posts", name: "IX_CreateUser_Id", newName: "IX_LastModifiedUser_Id");
            RenameColumn(table: "dbo.Posts", name: "CreateUser_Id", newName: "LastModifiedUser_Id");
            CreateIndex("dbo.Categories", "ModifiedUser_Id");
            CreateIndex("dbo.Categories", "CreateUser_Id");
            AddForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User", "Id");
        }
    }
}
