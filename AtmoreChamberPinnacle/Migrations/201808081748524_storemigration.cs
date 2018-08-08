namespace AtmoreChamber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storemigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductTitle = c.String(nullable: false),
                        ProductDescription = c.String(),
                        ProductIMG = c.Binary(),
                        ProductPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductType = c.String(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        imgSource = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            DropTable("dbo.Products");
        }
    }
}
