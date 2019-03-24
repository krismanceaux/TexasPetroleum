namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePricePerGallonColumnInFuelQuotesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelQuotes", "PricePerGallon", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FuelQuotes", "PricePerGallon");
        }
    }
}
