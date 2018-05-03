namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Categories", new[] { "Post_ID" });
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            DropColumn("dbo.Categories", "Post_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Post_ID", c => c.Int());
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            CreateIndex("dbo.Categories", "Post_ID");
            AddForeignKey("dbo.Categories", "Post_ID", "dbo.Posts", "ID");
        }
    }
}
