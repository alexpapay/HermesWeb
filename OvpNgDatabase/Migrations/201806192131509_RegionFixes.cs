namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ObjectModels", "RegionId", "dbo.GeoDatas");
            DropIndex("dbo.ObjectModels", new[] { "RegionId" });
            AddColumn("dbo.ObjectModels", "DistrictName", c => c.String());
            AddColumn("dbo.ObjectModels", "RegionName", c => c.String());
            AddColumn("dbo.ObjectModels", "Identifier", c => c.String());
            DropColumn("dbo.ObjectModels", "RegionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ObjectModels", "RegionId", c => c.Int(nullable: false));
            DropColumn("dbo.ObjectModels", "Identifier");
            DropColumn("dbo.ObjectModels", "RegionName");
            DropColumn("dbo.ObjectModels", "DistrictName");
            CreateIndex("dbo.ObjectModels", "RegionId");
            AddForeignKey("dbo.ObjectModels", "RegionId", "dbo.GeoDatas", "Id");
        }
    }
}
