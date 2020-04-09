namespace PhoneShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inititalizedv3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            RenameColumn(table: "dbo.Products", name: "CategoryID", newName: "Category_ID");
            AlterColumn("dbo.Products", "Category_ID", c => c.Int());
            CreateIndex("dbo.Products", "Category_ID");
            AddForeignKey("dbo.Products", "Category_ID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_ID" });
            AlterColumn("dbo.Products", "Category_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "Category_ID", newName: "CategoryID");
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
