namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VERSION3 : DbMigration
    {
        public override void Up()
        {
            
            DropForeignKey("dbo.AspNetUsers", "Categories_Id1", "dbo.Categories");
            
            DropIndex("dbo.AspNetUsers", new[] { "Categories_Id1" });
            
            AddColumn("dbo.AspNetUsers", "Category", c => c.String());
            
            
            DropColumn("dbo.AspNetUsers", "Categories_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Categories_Id1", c => c.Int());
            
            
            DropColumn("dbo.AspNetUsers", "Category");
            
            CreateIndex("dbo.AspNetUsers", "Categories_Id1");
            
            AddForeignKey("dbo.AspNetUsers", "Categories_Id1", "dbo.Categories", "Id");
            
        }
    }
}
