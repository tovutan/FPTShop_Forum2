namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String());
            AddColumn("dbo.User", "LastName", c => c.String());
            AlterColumn("dbo.Posts", "CreateBy", c => c.Int());
            AlterColumn("dbo.User", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tags", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Tags", "CreateBy", c => c.Int());
            AlterColumn("dbo.Tags", "UpdateBy", c => c.Int());
            AlterColumn("dbo.Logs", "CreateBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logs", "CreateBy", c => c.String());
            AlterColumn("dbo.Tags", "UpdateBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "CreateBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "CreateBy", c => c.Int(nullable: false));
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
        }
    }
}
