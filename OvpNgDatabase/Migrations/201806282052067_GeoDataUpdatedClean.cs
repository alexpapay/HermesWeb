namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeoDataUpdatedClean : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ObjectModels", "GeoDistrictId", c => c.Int(nullable: false));
            DropColumn("dbo.ObjectModels", "DistrictName");
            DropColumn("dbo.ObjectModels", "DistrictId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ObjectModels", "DistrictId", c => c.Int(nullable: false));
            AddColumn("dbo.ObjectModels", "DistrictName", c => c.String());
            DropColumn("dbo.ObjectModels", "GeoDistrictId");
        }
    }
}
