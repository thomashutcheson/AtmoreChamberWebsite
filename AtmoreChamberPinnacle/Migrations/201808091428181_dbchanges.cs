namespace AtmoreChamber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "DeletedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "DeletedDate");
        }
    }
}
