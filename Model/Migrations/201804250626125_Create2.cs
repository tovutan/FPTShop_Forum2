namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "LastPostUserID", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "CreateBy", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User");
            DropForeignKey("dbo.Posts", "LastModifiedUser_Id", "dbo.User");
            DropForeignKey("dbo.Tags", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.Tags", "UpdateUser_Id", "dbo.User");
            DropForeignKey("dbo.Logs", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.Categories", new[] { "CreateUser_Id" });
            DropIndex("dbo.Categories", new[] { "ModifiedUser_Id" });
            DropIndex("dbo.User", new[] { "CreateBy" });
            DropIndex("dbo.User", new[] { "UpdateBy" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.Posts", new[] { "LastPostUserID" });
            DropIndex("dbo.Posts", new[] { "LastModifiedUser_Id" });
            DropIndex("dbo.Tags", new[] { "CreateUser_Id" });
            DropIndex("dbo.Tags", new[] { "UpdateUser_Id" });
            DropIndex("dbo.Logs", new[] { "CreateUser_Id" });
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.UserLogin");
            DropPrimaryKey("dbo.UserRole");
            DropPrimaryKey("dbo.Role");
            AlterColumn("dbo.Categories", "CreateBy", c => c.Int());
            AlterColumn("dbo.Categories", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.Categories", "CreateUser_Id", c => c.Int());
            AlterColumn("dbo.Categories", "ModifiedUser_Id", c => c.Int());
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "CreateBy", c => c.Int());
            AlterColumn("dbo.User", "UpdateBy", c => c.Int());
            AlterColumn("dbo.UserClaim", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserLogin", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRole", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRole", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Role", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Posts", "LastPostUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "LastUserModifiedID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "LastModifiedUser_Id", c => c.Int());
            AlterColumn("dbo.Tags", "CreateBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "UpdateBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "CreateUser_Id", c => c.Int());
            AlterColumn("dbo.Tags", "UpdateUser_Id", c => c.Int());
            AlterColumn("dbo.Logs", "CreateUser_Id", c => c.Int());
            AddPrimaryKey("dbo.User", "Id");
            AddPrimaryKey("dbo.UserLogin", new[] { "UserId", "ProviderKey", "LoginProvider" });
            AddPrimaryKey("dbo.UserRole", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.Role", "Id");
            CreateIndex("dbo.Categories", "CreateUser_Id");
            CreateIndex("dbo.Categories", "ModifiedUser_Id");
            CreateIndex("dbo.User", "CreateBy");
            CreateIndex("dbo.User", "UpdateBy");
            CreateIndex("dbo.UserClaim", "UserId");
            CreateIndex("dbo.UserLogin", "UserId");
            CreateIndex("dbo.UserRole", "UserId");
            CreateIndex("dbo.UserRole", "RoleId");
            CreateIndex("dbo.Posts", "LastPostUserID");
            CreateIndex("dbo.Posts", "LastModifiedUser_Id");
            CreateIndex("dbo.Tags", "CreateUser_Id");
            CreateIndex("dbo.Tags", "UpdateUser_Id");
            CreateIndex("dbo.Logs", "CreateUser_Id");
            AddForeignKey("dbo.Posts", "LastPostUserID", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.User", "CreateBy", "dbo.User", "Id");
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.User", "UpdateBy", "dbo.User", "Id");
            AddForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Posts", "LastModifiedUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Tags", "CreateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Tags", "UpdateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Logs", "CreateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Logs", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.Tags", "UpdateUser_Id", "dbo.User");
            DropForeignKey("dbo.Tags", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.Posts", "LastModifiedUser_Id", "dbo.User");
            DropForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User");
            DropForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.User", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "CreateBy", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Posts", "LastPostUserID", "dbo.User");
            DropIndex("dbo.Logs", new[] { "CreateUser_Id" });
            DropIndex("dbo.Tags", new[] { "UpdateUser_Id" });
            DropIndex("dbo.Tags", new[] { "CreateUser_Id" });
            DropIndex("dbo.Posts", new[] { "LastModifiedUser_Id" });
            DropIndex("dbo.Posts", new[] { "LastPostUserID" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "UpdateBy" });
            DropIndex("dbo.User", new[] { "CreateBy" });
            DropIndex("dbo.Categories", new[] { "ModifiedUser_Id" });
            DropIndex("dbo.Categories", new[] { "CreateUser_Id" });
            DropPrimaryKey("dbo.Role");
            DropPrimaryKey("dbo.UserRole");
            DropPrimaryKey("dbo.UserLogin");
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.Logs", "CreateUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tags", "UpdateUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tags", "CreateUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tags", "UpdateBy", c => c.String());
            AlterColumn("dbo.Tags", "CreateBy", c => c.String());
            AlterColumn("dbo.Posts", "LastModifiedUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "LastUserModifiedID", c => c.String());
            AlterColumn("dbo.Posts", "LastPostUserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Role", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserRole", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserRole", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserLogin", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserClaim", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.User", "UpdateBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.User", "CreateBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.User", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "ModifiedUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Categories", "CreateUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Categories", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Categories", "CreateBy", c => c.String());
            AddPrimaryKey("dbo.Role", "Id");
            AddPrimaryKey("dbo.UserRole", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.UserLogin", new[] { "UserId", "ProviderKey", "LoginProvider" });
            AddPrimaryKey("dbo.User", "Id");
            CreateIndex("dbo.Logs", "CreateUser_Id");
            CreateIndex("dbo.Tags", "UpdateUser_Id");
            CreateIndex("dbo.Tags", "CreateUser_Id");
            CreateIndex("dbo.Posts", "LastModifiedUser_Id");
            CreateIndex("dbo.Posts", "LastPostUserID");
            CreateIndex("dbo.UserRole", "RoleId");
            CreateIndex("dbo.UserRole", "UserId");
            CreateIndex("dbo.UserLogin", "UserId");
            CreateIndex("dbo.UserClaim", "UserId");
            CreateIndex("dbo.User", "UpdateBy");
            CreateIndex("dbo.User", "CreateBy");
            CreateIndex("dbo.Categories", "ModifiedUser_Id");
            CreateIndex("dbo.Categories", "CreateUser_Id");
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Logs", "CreateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Tags", "UpdateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Tags", "CreateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Posts", "LastModifiedUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Categories", "ModifiedUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Categories", "CreateUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.User", "UpdateBy", "dbo.User", "Id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.User", "CreateBy", "dbo.User", "Id");
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "LastPostUserID", "dbo.User", "Id");
        }
    }
}
