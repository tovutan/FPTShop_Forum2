namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Quantity", c => c.Int());
            AlterColumn("dbo.Categories", "OrderDisplay", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "OrderDisplay", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Quantity", c => c.Int(nullable: false));
        }
    }
}
