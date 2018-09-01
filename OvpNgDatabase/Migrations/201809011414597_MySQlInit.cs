namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MySQlInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anticorrosives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purchase = c.String(unicode: false),
                        IsPaintAndVarnish = c.Boolean(nullable: false),
                        IsTubesInside = c.Boolean(nullable: false),
                        IsTubesOutside = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(nullable: false, unicode: false),
                        LastEditAt = c.DateTime(nullable: false, precision: 0),
                        LastEditBy = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        BusinessName = c.String(unicode: false),
                        Website = c.String(unicode: false),
                        CompanyProfileId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(nullable: false, unicode: false),
                        LastEditAt = c.DateTime(nullable: false, precision: 0),
                        LastEditBy = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(nullable: false, unicode: false),
                        LastEditAt = c.DateTime(nullable: false, precision: 0),
                        LastEditBy = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConstructionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(nullable: false, unicode: false),
                        LastEditAt = c.DateTime(nullable: false, precision: 0),
                        LastEditBy = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeoDataCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
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
                        Name = c.String(nullable: false, unicode: false),
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
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ObjectModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObjectName = c.String(unicode: false),
                        SubObjectId = c.Int(),
                        Subject = c.String(unicode: false),
                        CompletionRate = c.Int(nullable: false),
                        ConstructionTypeId = c.Int(nullable: false),
                        StageId = c.Int(nullable: false),
                        RegionName = c.String(unicode: false),
                        Identifier = c.String(unicode: false),
                        GeoDistrictId = c.Int(nullable: false),
                        ObjectStart = c.DateTime(nullable: false, precision: 0),
                        ObjectFinish = c.DateTime(nullable: false, precision: 0),
                        ConstructionStart = c.DateTime(nullable: false, precision: 0),
                        ConstructionFinish = c.DateTime(nullable: false, precision: 0),
                        DesignStart = c.DateTime(nullable: false, precision: 0),
                        DesignFinish = c.DateTime(nullable: false, precision: 0),
                        IsHaveCalculations = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        InvestorId = c.Int(nullable: false),
                        InvestorDepartmentId = c.Int(nullable: false),
                        GeneralContractorId = c.Int(nullable: false),
                        GeneralDesignerId = c.Int(nullable: false),
                        DesignerId = c.Int(nullable: false),
                        ConstructorId = c.Int(nullable: false),
                        NonDependentControllerId = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(nullable: false, unicode: false),
                        LastEditAt = c.DateTime(nullable: false, precision: 0),
                        LastEditBy = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConstructionTypes", t => t.ConstructionTypeId)
                .ForeignKey("dbo.Companies", t => t.ConstructorId)
                .ForeignKey("dbo.Companies", t => t.ContractorId)
                .ForeignKey("dbo.Companies", t => t.DesignerId)
                .ForeignKey("dbo.Companies", t => t.GeneralContractorId)
                .ForeignKey("dbo.Companies", t => t.GeneralDesignerId)
                .ForeignKey("dbo.Companies", t => t.InvestorId)
                .ForeignKey("dbo.Companies", t => t.InvestorDepartmentId)
                .ForeignKey("dbo.Companies", t => t.NonDependentControllerId)
                .ForeignKey("dbo.Companies", t => t.OwnerId)
                .ForeignKey("dbo.Stages", t => t.StageId)
                .Index(t => t.ConstructionTypeId)
                .Index(t => t.StageId)
                .Index(t => t.OwnerId)
                .Index(t => t.InvestorId)
                .Index(t => t.InvestorDepartmentId)
                .Index(t => t.GeneralContractorId)
                .Index(t => t.GeneralDesignerId)
                .Index(t => t.DesignerId)
                .Index(t => t.ConstructorId)
                .Index(t => t.NonDependentControllerId)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(nullable: false, unicode: false),
                        LastEditAt = c.DateTime(nullable: false, precision: 0),
                        LastEditBy = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThermalIsolations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purchase = c.String(unicode: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        Volume = c.Double(nullable: false),
                        Square = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(nullable: false, unicode: false),
                        LastEditAt = c.DateTime(nullable: false, precision: 0),
                        LastEditBy = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ObjectModels", "StageId", "dbo.Stages");
            DropForeignKey("dbo.ObjectModels", "OwnerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "NonDependentControllerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "InvestorDepartmentId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "InvestorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "GeneralDesignerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "GeneralContractorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "DesignerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "ContractorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "ConstructorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "ConstructionTypeId", "dbo.ConstructionTypes");
            DropForeignKey("dbo.GeoDataCities", "RegionId", "dbo.GeoDataRegions");
            DropForeignKey("dbo.GeoDataRegions", "DistrictId", "dbo.GeoDataDistricts");
            DropIndex("dbo.ObjectModels", new[] { "ContractorId" });
            DropIndex("dbo.ObjectModels", new[] { "NonDependentControllerId" });
            DropIndex("dbo.ObjectModels", new[] { "ConstructorId" });
            DropIndex("dbo.ObjectModels", new[] { "DesignerId" });
            DropIndex("dbo.ObjectModels", new[] { "GeneralDesignerId" });
            DropIndex("dbo.ObjectModels", new[] { "GeneralContractorId" });
            DropIndex("dbo.ObjectModels", new[] { "InvestorDepartmentId" });
            DropIndex("dbo.ObjectModels", new[] { "InvestorId" });
            DropIndex("dbo.ObjectModels", new[] { "OwnerId" });
            DropIndex("dbo.ObjectModels", new[] { "StageId" });
            DropIndex("dbo.ObjectModels", new[] { "ConstructionTypeId" });
            DropIndex("dbo.GeoDataRegions", new[] { "DistrictId" });
            DropIndex("dbo.GeoDataCities", new[] { "RegionId" });
            DropTable("dbo.ThermalIsolations");
            DropTable("dbo.Stages");
            DropTable("dbo.ObjectModels");
            DropTable("dbo.GeoDataDistricts");
            DropTable("dbo.GeoDataRegions");
            DropTable("dbo.GeoDataCities");
            DropTable("dbo.ConstructionTypes");
            DropTable("dbo.CompanyProfiles");
            DropTable("dbo.Companies");
            DropTable("dbo.Anticorrosives");
        }
    }
}
