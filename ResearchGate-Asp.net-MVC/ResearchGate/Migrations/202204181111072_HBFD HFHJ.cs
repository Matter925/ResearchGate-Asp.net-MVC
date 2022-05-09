namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HBFDHFHJ : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.AspNetUsers", new[] { "Category_Id1" });
            DropColumn("dbo.AspNetUsers", "Category_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Category_Id1", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Category_Id1");
            AddForeignKey("dbo.AspNetUsers", "Category_Id1", "dbo.Categories", "Id");
        }
    }
}
