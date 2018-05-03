namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create10 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", "UserNameIndex");
            AlterColumn("dbo.User", "UserName", c => c.String(maxLength: 256));
            CreateIndex("dbo.User", "UserName", name: "UserNameIndex");
           
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", "UserNameIndex");
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.User", "UserName", name: "UserNameIndex");
        }
    }
}
