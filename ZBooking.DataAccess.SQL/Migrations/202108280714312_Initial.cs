namespace ZBooking.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 20),
                        SubName = c.String(),
                        Description = c.String(),
                        Activity = c.String(),
                        image = c.String(),
                        Longitude = c.String(),
                        Latitude = c.String(),
                        DayPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HourPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VenueActivities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Category = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VenueActivities");
            DropTable("dbo.Venues");
        }
    }
}
