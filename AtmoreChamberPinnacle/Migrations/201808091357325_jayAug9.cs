namespace AtmoreChamber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jayAug9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductIMG", c => c.String());
            DropColumn("dbo.Members", "DeletedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "ProductIMG", c => c.Binary());
        }
    }
}
