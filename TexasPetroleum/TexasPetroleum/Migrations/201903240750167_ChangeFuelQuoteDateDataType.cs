namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFuelQuoteDateDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FuelQuotes", "DeliveryDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FuelQuotes", "TimeCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FuelQuotes", "TimeCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FuelQuotes", "DeliveryDate", c => c.DateTime(nullable: false));
        }
    }
}
