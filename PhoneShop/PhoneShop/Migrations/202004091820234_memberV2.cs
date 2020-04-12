namespace PhoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "UserPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "UserPassword", c => c.String());
            AlterColumn("dbo.Members", "UserId", c => c.String());
        }
    }
}
