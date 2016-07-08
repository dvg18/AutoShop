namespace AutoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InfoVisits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitDate = c.DateTime(nullable: false),
                        ApplicationUserId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InfoVisits", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.InfoVisits", new[] { "ApplicationUser_Id" });
            DropTable("dbo.InfoVisits");
        }
    }
}
