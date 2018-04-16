namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostCategories", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.PostCategories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.PostCategories", new[] { "Post_ID" });
            DropIndex("dbo.PostCategories", new[] { "Category_ID" });
            AddColumn("dbo.Categories", "Post_ID", c => c.Int());
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tags", "IsShow", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Categories", "Post_ID");
            AddForeignKey("dbo.Categories", "Post_ID", "dbo.Posts", "ID");
            DropTable("dbo.PostCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Post_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_ID, t.Category_ID });
            
            DropForeignKey("dbo.Categories", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Categories", new[] { "Post_ID" });
            AlterColumn("dbo.Tags", "IsShow", c => c.Boolean());
            AlterColumn("dbo.Tags", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int());
            DropColumn("dbo.Categories", "Post_ID");
            CreateIndex("dbo.PostCategories", "Category_ID");
            CreateIndex("dbo.PostCategories", "Post_ID");
            AddForeignKey("dbo.PostCategories", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PostCategories", "Post_ID", "dbo.Posts", "ID", cascadeDelete: true);
        }
    }
}
