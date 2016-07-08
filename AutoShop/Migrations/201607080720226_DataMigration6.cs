namespace AutoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.InfoVisits", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.InfoVisits", "ApplicationUserId");
            RenameColumn(table: "dbo.InfoVisits", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.InfoVisits", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.InfoVisits", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.InfoVisits", new[] { "ApplicationUserId" });
            AlterColumn("dbo.InfoVisits", "ApplicationUserId", c => c.Int());
            RenameColumn(table: "dbo.InfoVisits", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.InfoVisits", "ApplicationUserId", c => c.Int());
            CreateIndex("dbo.InfoVisits", "ApplicationUser_Id");
        }
    }
}
