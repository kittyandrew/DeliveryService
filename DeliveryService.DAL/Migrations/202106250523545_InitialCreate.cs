namespace DeliveryService.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryTime = c.DateTime(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        TransportId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Transports", t => t.TransportId, cascadeDelete: true)
                .Index(t => t.PlaceId)
                .Index(t => t.TransportId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Distance = c.Double(nullable: false),
                        Traffic = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        ProductTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId)
                .Index(t => t.ProductTypeId);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TransportTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransportTypes", t => t.TransportTypeId)
                .Index(t => t.TransportTypeId);
            
            CreateTable(
                "dbo.TransportTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxSize = c.Double(nullable: false),
                        MaxWeight = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FreeBy = c.DateTime(nullable: false),
                        TransportTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransportTypes", t => t.TransportTypeId)
                .Index(t => t.TransportTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deliveries", "TransportId", "dbo.Transports");
            DropForeignKey("dbo.Transports", "TransportTypeId", "dbo.TransportTypes");
            DropForeignKey("dbo.Deliveries", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.ProductTypes", "TransportTypeId", "dbo.TransportTypes");
            DropForeignKey("dbo.Deliveries", "PlaceId", "dbo.Places");
            DropIndex("dbo.Transports", new[] { "TransportTypeId" });
            DropIndex("dbo.ProductTypes", new[] { "TransportTypeId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.Deliveries", new[] { "ProductId" });
            DropIndex("dbo.Deliveries", new[] { "TransportId" });
            DropIndex("dbo.Deliveries", new[] { "PlaceId" });
            DropTable("dbo.Transports");
            DropTable("dbo.TransportTypes");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Places");
            DropTable("dbo.Deliveries");
        }
    }
}
