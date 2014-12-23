namespace Dishes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IngredientCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Ingredients", "Category_ID", c => c.Int());
            CreateIndex("dbo.Ingredients", "Category_ID");
            AddForeignKey("dbo.Ingredients", "Category_ID", "dbo.IngredientCategories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Category_ID", "dbo.IngredientCategories");
            DropIndex("dbo.Ingredients", new[] { "Category_ID" });
            DropColumn("dbo.Ingredients", "Category_ID");
            DropTable("dbo.IngredientCategories");
        }
    }
}
