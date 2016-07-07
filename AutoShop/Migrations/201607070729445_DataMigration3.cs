namespace AutoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Discount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Visits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Visits");
            DropColumn("dbo.AspNetUsers", "Discount");
        }
    }
}
