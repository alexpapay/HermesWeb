namespace OvpNgDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObjectDataEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ObjectModels", "ObjectStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.ObjectModels", "ObjectFinish", c => c.DateTime(nullable: false));
            AddColumn("dbo.ObjectModels", "DesignStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.ObjectModels", "DesignFinish", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ObjectModels", "DesignFinish");
            DropColumn("dbo.ObjectModels", "DesignStart");
            DropColumn("dbo.ObjectModels", "ObjectFinish");
            DropColumn("dbo.ObjectModels", "ObjectStart");
        }
    }
}
