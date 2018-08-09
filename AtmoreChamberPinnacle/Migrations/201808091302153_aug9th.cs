namespace AtmoreChamber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aug9th : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductIMG", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductIMG", c => c.Binary());
        }
    }
}
