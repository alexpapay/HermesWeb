namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeoDataUpdatedFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ObjectModels", "DistrictId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ObjectModels", "DistrictId");
        }
    }
}
