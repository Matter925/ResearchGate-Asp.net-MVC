namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AINSERTNEWRELTIONL4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RegisterViewModels", "Categories_Id");
            DropColumn("dbo.AspNetUsers", "Categories_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Categories_Id", c => c.Int(nullable: false));
            AddColumn("dbo.RegisterViewModels", "Categories_Id", c => c.Int(nullable: false));
        }
    }
}
