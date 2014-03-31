namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MonsterShop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Monster",
                c => new
                    {
                        MonsterId = c.Int(nullable: false, identity: true),
                        MonsterName = c.String(nullable: false, maxLength: 50),
                        PurchasePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MonsterId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderGuid = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Sum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderGuid);
            
            CreateTable(
                "dbo.OrderLine",
                c => new
                    {
                        OrderLineId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        MonsterId = c.Int(nullable: false),
                        OrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderLineId)
                .ForeignKey("dbo.Monster", t => t.MonsterId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.MonsterId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLine", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderLine", "MonsterId", "dbo.Monster");
            DropIndex("dbo.OrderLine", new[] { "OrderId" });
            DropIndex("dbo.OrderLine", new[] { "MonsterId" });
            DropTable("dbo.OrderLine");
            DropTable("dbo.Order");
            DropTable("dbo.Monster");
        }
    }
}
