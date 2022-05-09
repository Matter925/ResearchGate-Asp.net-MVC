namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDNEWRELTIONBETWEENV10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterViewModels", "Categories_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Categories_Id", c => c.Int());
            CreateIndex("dbo.RegisterViewModels", "Categories_Id");
            CreateIndex("dbo.AspNetUsers", "Categories_Id");
            AddForeignKey("dbo.RegisterViewModels", "Categories_Id", "dbo.Categories", "Category_Id");
            AddForeignKey("dbo.AspNetUsers", "Categories_Id", "dbo.Categories", "Category_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Categories_Id", "dbo.Categories");
            DropForeignKey("dbo.RegisterViewModels", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.AspNetUsers", new[] { "Categories_Id" });
            DropIndex("dbo.RegisterViewModels", new[] { "Categories_Id" });
            DropColumn("dbo.AspNetUsers", "Categories_Id");
            DropColumn("dbo.RegisterViewModels", "Categories_Id");
        }
    }
}
