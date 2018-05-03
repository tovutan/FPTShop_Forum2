namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "LastPostUserID", "dbo.User");
            DropIndex("dbo.Posts", new[] { "LastPostUserID" });
            AlterColumn("dbo.Posts", "UpdateBy", c => c.Int());
            AlterColumn("dbo.Posts", "LastPostUserID", c => c.Int());
            CreateIndex("dbo.Posts", "LastPostUserID");
            AddForeignKey("dbo.Posts", "LastPostUserID", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "LastPostUserID", "dbo.User");
            DropIndex("dbo.Posts", new[] { "LastPostUserID" });
            AlterColumn("dbo.Posts", "LastPostUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "UpdateBy", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "LastPostUserID");
            AddForeignKey("dbo.Posts", "LastPostUserID", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
