namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePricePerGallon : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FuelQuotes", "PricePerGallon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FuelQuotes", "PricePerGallon", c => c.Double(nullable: false));
        }
    }
}
