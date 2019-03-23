namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateClient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Guid(nullable: false),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Clients", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.FuelQuotes",
                c => new
                    {
                        QuoteId = c.Guid(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        TimeCreated = c.DateTime(nullable: false),
                        SuggestedPrice = c.Double(nullable: false),
                        GallonsRequested = c.Double(nullable: false),
                        Client_ClientId = c.Guid(nullable: false),
                        DeliveryAddress_AddressId = c.Guid(),
                    })
                .PrimaryKey(t => t.QuoteId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.DeliveryAddress_AddressId)
                .Index(t => t.Client_ClientId)
                .Index(t => t.DeliveryAddress_AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Clients");
            DropForeignKey("dbo.FuelQuotes", "DeliveryAddress_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.FuelQuotes", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.FuelQuotes", new[] { "DeliveryAddress_AddressId" });
            DropIndex("dbo.FuelQuotes", new[] { "Client_ClientId" });
            DropIndex("dbo.Addresses", new[] { "AddressId" });
            DropTable("dbo.FuelQuotes");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
