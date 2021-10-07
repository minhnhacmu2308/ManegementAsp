namespace ManagementAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        idCat = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCat);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        idProduct = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        image = c.String(nullable: false, maxLength: 255),
                        description = c.String(),
                        cost = c.Int(nullable: false),
                        number = c.Int(nullable: false),
                        idCat = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProduct)
                .ForeignKey("dbo.Categories", t => t.idCat, cascadeDelete: true)
                .Index(t => t.idCat);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        idOrder = c.Int(nullable: false, identity: true),
                        idTransaction = c.Int(nullable: false),
                        idProduct = c.Int(nullable: false),
                        number = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idOrder)
                .ForeignKey("dbo.Products", t => t.idProduct, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.idTransaction, cascadeDelete: true)
                .Index(t => t.idTransaction)
                .Index(t => t.idProduct);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        idTranSaction = c.Int(nullable: false, identity: true),
                        amount = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTranSaction);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "idTransaction", "dbo.Transactions");
            DropForeignKey("dbo.Orders", "idProduct", "dbo.Products");
            DropForeignKey("dbo.Products", "idCat", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "idProduct" });
            DropIndex("dbo.Orders", new[] { "idTransaction" });
            DropIndex("dbo.Products", new[] { "idCat" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
