namespace ResearchGate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JHHJBHJB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participators", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participators", "Name");
        }
    }
}
