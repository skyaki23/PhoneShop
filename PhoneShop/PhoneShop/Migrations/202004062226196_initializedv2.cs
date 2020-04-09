namespace PhoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializedv2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Description");
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Categories", "Description", c => c.String(maxLength: 500));
        }
    }
}
