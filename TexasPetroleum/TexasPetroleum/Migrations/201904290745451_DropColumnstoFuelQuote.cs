namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumnstoFuelQuote : DbMigration
    {
        public override void Up()
        {
            DropColumn("FuelQuote.FuelQuote", "TransportCharge");
            DropColumn("FuelQuote.FuelQuote", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("FuelQuote.FuelQuote", "Discount", c => c.Double(nullable: false));
            AddColumn("FuelQuote.FuelQuote", "TransportCharge", c => c.Double(nullable: false));
        }
    }
}
