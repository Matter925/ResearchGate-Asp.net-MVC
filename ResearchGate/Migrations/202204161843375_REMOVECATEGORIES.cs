namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REMOVECATEGORIES : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
        }
    }
}
