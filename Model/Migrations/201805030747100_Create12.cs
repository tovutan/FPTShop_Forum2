namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "ParentID", "dbo.Category");
            DropIndex("dbo.Category", new[] { "ParentID" });
            AddColumn("dbo.Category", "ParentCategory_ID", c => c.Int());
            CreateIndex("dbo.Category", "ParentCategory_ID");
            AddForeignKey("dbo.Category", "ParentCategory_ID", "dbo.Category", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "ParentCategory_ID", "dbo.Category");
            DropIndex("dbo.Category", new[] { "ParentCategory_ID" });
            DropColumn("dbo.Category", "ParentCategory_ID");
            CreateIndex("dbo.Category", "ParentID");
            AddForeignKey("dbo.Category", "ParentID", "dbo.Category", "ID");
        }
    }
}
