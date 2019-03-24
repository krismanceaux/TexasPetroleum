namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.FuelQuotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryDate = c.DateTime(nullable: false),
                        TimeCreated = c.DateTime(nullable: false),
                        SuggestedPrice = c.Double(nullable: false),
                        GallonsRequested = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Client_Id = c.Int(),
                        DeliveryAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Addresses", t => t.DeliveryAddress_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.DeliveryAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FuelQuotes", "DeliveryAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.FuelQuotes", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.FuelQuotes", new[] { "DeliveryAddress_Id" });
            DropIndex("dbo.FuelQuotes", new[] { "Client_Id" });
            DropIndex("dbo.Clients", new[] { "Address_Id" });
            DropTable("dbo.FuelQuotes");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
