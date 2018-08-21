namespace AtmoreChamber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            DropColumn("dbo.Products", "ProductIMG");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductIMG", c => c.String());
            DropColumn("dbo.Products", "ImagePath");
        }
    }
}
