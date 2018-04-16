namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        SEOTitle = c.String(),
                        SEOKeyword = c.String(),
                        SEODescription = c.String(),
                        Quantity = c.Int(nullable: false),
                        ParentID = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                        OrderDisplay = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        ParentCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_ID)
                .Index(t => t.ParentCategory_ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UrlSlug = c.String(),
                        Content = c.String(),
                        Image = c.String(),
                        SEOTitle = c.String(),
                        SEOKeyword = c.String(),
                        SEODescription = c.String(),
                        RelateProducts = c.String(),
                        Like = c.Int(),
                        Dislike = c.Int(),
                        PostTypeID = c.Int(),
                        CategoryID = c.Int(),
                        UserID = c.Int(),
                        Viewed = c.Int(),
                        DateCreate = c.DateTime(nullable: false),
                        DateModified = c.DateTime(),
                        LastPostUserName = c.String(),
                        LastPostUserID = c.String(),
                        UserModifiedID = c.String(),
                        LastPostDate = c.DateTime(),
                        TotalPost = c.Int(),
                        OrderDisplay = c.Int(),
                        IsHot = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        ImageURL = c.String(),
                        Link = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        PinInSearch = c.Boolean(nullable: false),
                        SeoTitle = c.String(),
                        SeoKeyword = c.String(),
                        SeoDescription = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                        CreateUser_Id = c.String(maxLength: 128),
                        UpdateUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreateUser_Id)
                .ForeignKey("dbo.User", t => t.UpdateUser_Id)
                .Index(t => t.CreateUser_Id)
                .Index(t => t.UpdateUser_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 128),
                        UpdateBy = c.String(maxLength: 128),
                        FullName = c.String(maxLength: 500),
                        ImageURL = c.String(),
                        AuthorName = c.String(),
                        Description = c.String(),
                        Email = c.String(maxLength: 300),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreateBy)
                .ForeignKey("dbo.User", t => t.UpdateBy)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy)
                .Index(t => t.UserName, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProviderKey, t.LoginProvider })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        Image = c.String(),
                        BirthDay = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Type = c.Int(nullable: false),
                        DataAccess = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        CreateUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.CreateUser_Id)
                .Index(t => t.CreateUser_Id);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Post_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_ID, t.Category_ID })
                .ForeignKey("dbo.Posts", t => t.Post_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Post_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_ID })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_ID, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.Tags", "UpdateUser_Id", "dbo.User");
            DropForeignKey("dbo.TagPosts", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Tags", "CreateUser_Id", "dbo.User");
            DropForeignKey("dbo.User", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "CreateBy", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.PostCategories", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.PostCategories", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.Categories", "ParentCategory_ID", "dbo.Categories");
            DropIndex("dbo.TagPosts", new[] { "Post_ID" });
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropIndex("dbo.PostCategories", new[] { "Category_ID" });
            DropIndex("dbo.PostCategories", new[] { "Post_ID" });
            DropIndex("dbo.Logs", new[] { "CreateUser_Id" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", new[] { "UpdateBy" });
            DropIndex("dbo.User", new[] { "CreateBy" });
            DropIndex("dbo.Tags", new[] { "UpdateUser_Id" });
            DropIndex("dbo.Tags", new[] { "CreateUser_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_ID" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Logs");
            DropTable("dbo.Customers");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
