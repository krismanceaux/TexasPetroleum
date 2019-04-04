namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeClientAttributesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("FuelQuote.Client", "Name", c => c.String(maxLength: 50));
            AlterColumn("FuelQuote.Client", "AddressLine1", c => c.String(maxLength: 100));
            AlterColumn("FuelQuote.Client", "City", c => c.String(maxLength: 100));
            AlterColumn("FuelQuote.Client", "State", c => c.String(maxLength: 2));
            AlterColumn("FuelQuote.Client", "ZipCode", c => c.String(maxLength: 9));
        }
        
        public override void Down()
        {
            AlterColumn("FuelQuote.Client", "ZipCode", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("FuelQuote.Client", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("FuelQuote.Client", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("FuelQuote.Client", "AddressLine1", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("FuelQuote.Client", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
