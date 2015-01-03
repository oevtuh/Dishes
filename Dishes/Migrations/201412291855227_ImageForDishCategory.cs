namespace Dishes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageForDishCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DishCategories", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DishCategories", "Image");
        }
    }
}
