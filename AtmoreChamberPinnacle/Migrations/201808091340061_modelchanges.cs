namespace AtmoreChamber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "ProductIMG", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductIMG", c => c.String());
            DropColumn("dbo.Members", "DeletedDate");
        }
    }
}
