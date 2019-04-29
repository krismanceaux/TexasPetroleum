namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnstoFuelQuote : DbMigration
    {
        public override void Up()
        {
            AddColumn("FuelQuote.FuelQuote", "TransportCharge", c => c.Double(nullable: false));
            AddColumn("FuelQuote.FuelQuote", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("FuelQuote.FuelQuote", "Discount");
            DropColumn("FuelQuote.FuelQuote", "TransportCharge");
        }
    }
}
