namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDNEWREGESTER : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.RegisterViewModels",
               c => new
               {
                   Id = c.String(nullable: false, maxLength: 128),
                   FirstName = c.String(nullable: false),
                   LastName = c.String(nullable: false),
                   ProfileImage = c.String(),
                   University = c.String(nullable: false),
                   Mobile = c.String(nullable: false),
                   Email = c.String(nullable: false),
                   Password = c.String(nullable: false, maxLength: 100),
                   ConfirmPassword = c.String(),
                   Category = c.String(),
               })
               .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterViewModels");
        }
    }
}
