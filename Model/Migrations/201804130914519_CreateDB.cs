namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "ID");
        }
    }
}
