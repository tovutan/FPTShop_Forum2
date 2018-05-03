namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "IsShow", c => c.Boolean());
            AlterColumn("dbo.Categories", "IsDelete", c => c.Boolean());
            AlterColumn("dbo.Posts", "IsHot", c => c.Boolean());
            AlterColumn("dbo.Posts", "IsApproved", c => c.Boolean());
            AlterColumn("dbo.Posts", "IsShow", c => c.Boolean());
            AlterColumn("dbo.Posts", "IsDelete", c => c.Boolean());
            AlterColumn("dbo.Tags", "IsDeleted", c => c.Boolean());
            AlterColumn("dbo.Tags", "IsShow", c => c.Boolean());
            AlterColumn("dbo.Tags", "PinInSearch", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "PinInSearch", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tags", "IsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tags", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Posts", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Posts", "IsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Posts", "IsApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Posts", "IsHot", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Categories", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Categories", "IsShow", c => c.Boolean(nullable: false));
        }
    }
}
