namespace PhoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class member : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        UserPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
