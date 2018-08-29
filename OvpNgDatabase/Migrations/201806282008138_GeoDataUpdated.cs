namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeoDataUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeoDataCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeoDataRegions", t => t.RegionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.GeoDataRegions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeoDataDistricts", t => t.DistrictId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.GeoDataDistricts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.GeoDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GeoDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        District = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        Identifier = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.GeoDataCities", "RegionId", "dbo.GeoDataRegions");
            DropForeignKey("dbo.GeoDataRegions", "DistrictId", "dbo.GeoDataDistricts");
            DropIndex("dbo.GeoDataRegions", new[] { "DistrictId" });
            DropIndex("dbo.GeoDataCities", new[] { "RegionId" });
            DropTable("dbo.GeoDataDistricts");
            DropTable("dbo.GeoDataRegions");
            DropTable("dbo.GeoDataCities");
        }
    }
}
