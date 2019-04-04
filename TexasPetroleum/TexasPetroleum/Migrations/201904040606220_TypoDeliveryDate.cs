namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypoDeliveryDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("FuelQuote.FuelQuote", "DeliveryDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("FuelQuote.FuelQuote", "DevliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("FuelQuote.FuelQuote", "DevliveryDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("FuelQuote.FuelQuote", "DeliveryDate");
        }
    }
}
