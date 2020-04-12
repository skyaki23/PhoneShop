namespace PhoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "UserPhone", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "UserEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "UserEmail");
            DropColumn("dbo.Members", "UserPhone");
        }
    }
}
