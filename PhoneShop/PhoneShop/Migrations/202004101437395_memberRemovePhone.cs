namespace PhoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberRemovePhone : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "UserPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "UserPhone", c => c.Int(nullable: false));
        }
    }
}
