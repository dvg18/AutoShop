namespace AutoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        busy = c.Boolean(nullable: false),
                        InfoVisitId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InfoVisits", t => t.InfoVisitId)
                .Index(t => t.InfoVisitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutoCars", "InfoVisitId", "dbo.InfoVisits");
            DropIndex("dbo.AutoCars", new[] { "InfoVisitId" });
            DropTable("dbo.AutoCars");
        }
    }
}
