namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anticorrosives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purchase = c.String(),
                        IsPaintAndVarnish = c.Boolean(nullable: false),
                        IsTubesInside = c.Boolean(nullable: false),
                        IsTubesOutside = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BusinessName = c.String(),
                        Website = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConstructionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeoDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        District = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        Identifier = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ObjectModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObjectName = c.String(),
                        SubObjectId = c.Int(),
                        Subject = c.String(),
                        CompletionRate = c.Int(nullable: false),
                        ConstructionTypeId = c.Int(nullable: false),
                        StageId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                        ConstructionStart = c.DateTime(nullable: false),
                        ConstructionFinish = c.DateTime(nullable: false),
                        IsHaveCalculations = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        InvestorId = c.Int(nullable: false),
                        InvestorDepartmentId = c.Int(nullable: false),
                        GeneralContractorId = c.Int(nullable: false),
                        GeneralDesignerId = c.Int(nullable: false),
                        DesignerId = c.Int(nullable: false),
                        ConstructorId = c.Int(nullable: false),
                        NonDependentControllerId = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConstructionTypes", t => t.ConstructionTypeId)
                .ForeignKey("dbo.Companies", t => t.ConstructorId)
                .ForeignKey("dbo.Companies", t => t.ContractorId)
                .ForeignKey("dbo.Companies", t => t.CustomerId)
                .ForeignKey("dbo.Companies", t => t.DesignerId)
                .ForeignKey("dbo.Companies", t => t.GeneralContractorId)
                .ForeignKey("dbo.Companies", t => t.GeneralDesignerId)
                .ForeignKey("dbo.Companies", t => t.InvestorId)
                .ForeignKey("dbo.Companies", t => t.InvestorDepartmentId)
                .ForeignKey("dbo.Companies", t => t.NonDependentControllerId)
                .ForeignKey("dbo.Companies", t => t.OwnerId)
                .ForeignKey("dbo.GeoDatas", t => t.RegionId)
                .ForeignKey("dbo.Stages", t => t.StageId)
                .Index(t => t.ConstructionTypeId)
                .Index(t => t.StageId)
                .Index(t => t.RegionId)
                .Index(t => t.CustomerId)
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
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThermalIsolations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purchase = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        Volume = c.Double(nullable: false),
                        Square = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastEditAt = c.DateTime(nullable: false),
                        LastEditBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ObjectModels", "StageId", "dbo.Stages");
            DropForeignKey("dbo.ObjectModels", "RegionId", "dbo.GeoDatas");
            DropForeignKey("dbo.ObjectModels", "OwnerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "NonDependentControllerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "InvestorDepartmentId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "InvestorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "GeneralDesignerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "GeneralContractorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "DesignerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "CustomerId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "ContractorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "ConstructorId", "dbo.Companies");
            DropForeignKey("dbo.ObjectModels", "ConstructionTypeId", "dbo.ConstructionTypes");
            DropIndex("dbo.ObjectModels", new[] { "ContractorId" });
            DropIndex("dbo.ObjectModels", new[] { "NonDependentControllerId" });
            DropIndex("dbo.ObjectModels", new[] { "ConstructorId" });
            DropIndex("dbo.ObjectModels", new[] { "DesignerId" });
            DropIndex("dbo.ObjectModels", new[] { "GeneralDesignerId" });
            DropIndex("dbo.ObjectModels", new[] { "GeneralContractorId" });
            DropIndex("dbo.ObjectModels", new[] { "InvestorDepartmentId" });
            DropIndex("dbo.ObjectModels", new[] { "InvestorId" });
            DropIndex("dbo.ObjectModels", new[] { "OwnerId" });
            DropIndex("dbo.ObjectModels", new[] { "CustomerId" });
            DropIndex("dbo.ObjectModels", new[] { "RegionId" });
            DropIndex("dbo.ObjectModels", new[] { "StageId" });
            DropIndex("dbo.ObjectModels", new[] { "ConstructionTypeId" });
            DropTable("dbo.ThermalIsolations");
            DropTable("dbo.Stages");
            DropTable("dbo.ObjectModels");
            DropTable("dbo.GeoDatas");
            DropTable("dbo.ConstructionTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.Anticorrosives");
        }
    }
}
