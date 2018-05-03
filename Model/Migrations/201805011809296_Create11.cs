namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Post", "Like");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Like", c => c.Int());
        }
    }
}
