namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create8 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Post", "LastPostUserID");
            AddForeignKey("dbo.Post", "LastPostUserID", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "LastPostUserID", "dbo.User");
            DropIndex("dbo.Post", new[] { "LastPostUserID" });
        }
    }
}
