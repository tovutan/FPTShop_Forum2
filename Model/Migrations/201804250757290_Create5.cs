namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "LastPostUserID", "dbo.User");
            DropIndex("dbo.Posts", new[] { "LastPostUserID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Posts", "LastPostUserID");
            AddForeignKey("dbo.Posts", "LastPostUserID", "dbo.User", "Id");
        }
    }
}
