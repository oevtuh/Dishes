namespace Dishes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDishCategoryDishesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DishCategoryDishes", newName: "DishDishCategories");
            DropPrimaryKey("dbo.DishDishCategories");
            AddPrimaryKey("dbo.DishDishCategories", new[] { "Dish_ID", "DishCategory_ID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DishDishCategories");
            AddPrimaryKey("dbo.DishDishCategories", new[] { "DishCategory_ID", "Dish_ID" });
            RenameTable(name: "dbo.DishDishCategories", newName: "DishCategoryDishes");
        }
    }
}
