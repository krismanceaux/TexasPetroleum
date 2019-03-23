namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdaterelationshipsinonModelCreating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Clients");
            AddForeignKey("dbo.Addresses", "AddressId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Clients");
            AddForeignKey("dbo.Addresses", "AddressId", "dbo.Clients", "ClientId");
        }
    }
}
