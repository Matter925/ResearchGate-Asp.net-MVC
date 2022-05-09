namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JHBJH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Name");
        }
    }
}
