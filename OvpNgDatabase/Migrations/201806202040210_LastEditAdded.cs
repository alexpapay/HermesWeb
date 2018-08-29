namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastEditAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anticorrosives", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Anticorrosives", "LastEditBy", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "LastEditBy", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyProfiles", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyProfiles", "LastEditBy", c => c.String(nullable: false));
            AlterColumn("dbo.ConstructionTypes", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.ConstructionTypes", "LastEditBy", c => c.String(nullable: false));
            AlterColumn("dbo.GeoDatas", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.GeoDatas", "LastEditBy", c => c.String(nullable: false));
            AlterColumn("dbo.ObjectModels", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.ObjectModels", "LastEditBy", c => c.String(nullable: false));
            AlterColumn("dbo.Stages", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Stages", "LastEditBy", c => c.String(nullable: false));
            AlterColumn("dbo.ThermalIsolations", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.ThermalIsolations", "LastEditBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ThermalIsolations", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ThermalIsolations", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Stages", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Stages", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ObjectModels", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ObjectModels", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.GeoDatas", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.GeoDatas", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ConstructionTypes", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ConstructionTypes", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyProfiles", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyProfiles", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Companies", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Companies", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Anticorrosives", "LastEditBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Anticorrosives", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
