namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelQuotes", "DeliveryAddress_Id", c => c.Guid());
            CreateIndex("dbo.FuelQuotes", "DeliveryAddress_Id");
            AddForeignKey("dbo.FuelQuotes", "DeliveryAddress_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FuelQuotes", "DeliveryAddress_Id", "dbo.Addresses");
            DropIndex("dbo.FuelQuotes", new[] { "DeliveryAddress_Id" });
            DropColumn("dbo.FuelQuotes", "DeliveryAddress_Id");
        }
    }
}
