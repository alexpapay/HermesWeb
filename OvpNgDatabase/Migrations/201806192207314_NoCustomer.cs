namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ObjectModels", "CustomerId", "dbo.Companies");
            DropIndex("dbo.ObjectModels", new[] { "CustomerId" });
            DropColumn("dbo.ObjectModels", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ObjectModels", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ObjectModels", "CustomerId");
            AddForeignKey("dbo.ObjectModels", "CustomerId", "dbo.Companies", "Id");
        }
    }
}
