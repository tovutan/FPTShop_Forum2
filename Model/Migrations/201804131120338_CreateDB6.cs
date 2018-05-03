namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsPublic", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "IsPublic");
        }
    }
}
