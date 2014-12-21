namespace Dishes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDishes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "ShortDescription");
        }
    }
}
