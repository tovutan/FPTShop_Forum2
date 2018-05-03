namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Like", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "Like");
        }
    }
}
