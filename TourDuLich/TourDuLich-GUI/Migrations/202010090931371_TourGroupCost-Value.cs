namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TourGroupCostValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourGroupCosts", "Value", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourGroupCosts", "Value");
        }
    }
}
