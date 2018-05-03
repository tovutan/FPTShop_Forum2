namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CreateBy", c => c.String());
            AddColumn("dbo.Categories", "ModifiedBy", c => c.String());
            AddColumn("dbo.Categories", "CreateUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Categories", "ModifiedUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "LastUserModifiedID", c => c.String());
            AddColumn("dbo.Posts", "LastModifiedUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "LastPostUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "CreateUser_Id");
            CreateIndex("dbo.Categories", "ModifiedUser_Id");
            CreateIndex("dbo.Posts", "LastPostUserID");
            CreateIndex("dbo.Posts", "LastModifiedUser_Id");
            AddForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Posts", "LastModifiedUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Posts", "LastPostUserID", "dbo.User", "Id");
            DropColumn("dbo.Posts", "UserModifiedID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserModifiedID", c => c.String());
            DropForeignKey("dbo.Posts", "LastPostUserID", "dbo.User");
            DropForeignKey("dbo.Posts", "LastModifiedUser_Id", "dbo.User");
            DropForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User");
            DropForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User");
            DropIndex("dbo.Posts", new[] { "LastModifiedUser_Id" });
            DropIndex("dbo.Posts", new[] { "LastPostUserID" });
            DropIndex("dbo.Categories", new[] { "ModifiedUser_Id" });
            DropIndex("dbo.Categories", new[] { "CreateUser_Id" });
            AlterColumn("dbo.Posts", "LastPostUserID", c => c.String());
            DropColumn("dbo.Posts", "LastModifiedUser_Id");
            DropColumn("dbo.Posts", "LastUserModifiedID");
            DropColumn("dbo.Categories", "ModifiedUser_Id");
            DropColumn("dbo.Categories", "CreateUser_Id");
            DropColumn("dbo.Categories", "ModifiedBy");
            DropColumn("dbo.Categories", "CreateBy");
        }
    }
}
