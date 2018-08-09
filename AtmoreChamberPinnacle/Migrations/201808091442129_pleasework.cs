namespace AtmoreChamber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasework : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "DeletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "DeletedDate", c => c.DateTime(nullable: false));
        }
    }
}
