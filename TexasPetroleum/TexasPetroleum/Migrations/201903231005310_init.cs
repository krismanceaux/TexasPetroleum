namespace TexasPetroleum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "Password");
        }
    }
}
