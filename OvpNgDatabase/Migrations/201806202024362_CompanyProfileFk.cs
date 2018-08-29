namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyProfileFk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyProfileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "CompanyProfileId");
        }
    }
}
