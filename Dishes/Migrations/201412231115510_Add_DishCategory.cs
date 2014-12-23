namespace Dishes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DishCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DishCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DishCategoryDishes",
                c => new
                    {
                        DishCategory_ID = c.Int(nullable: false),
                        Dish_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DishCategory_ID, t.Dish_ID })
                .ForeignKey("dbo.DishCategories", t => t.DishCategory_ID, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.Dish_ID, cascadeDelete: true)
                .Index(t => t.DishCategory_ID)
                .Index(t => t.Dish_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DishCategoryDishes", "Dish_ID", "dbo.Dishes");
            DropForeignKey("dbo.DishCategoryDishes", "DishCategory_ID", "dbo.DishCategories");
            DropIndex("dbo.DishCategoryDishes", new[] { "Dish_ID" });
            DropIndex("dbo.DishCategoryDishes", new[] { "DishCategory_ID" });
            DropTable("dbo.DishCategoryDishes");
            DropTable("dbo.DishCategories");
        }
    }
}
