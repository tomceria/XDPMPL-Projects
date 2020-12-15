namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TourGroupTourPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourGroups", "TourPrice", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourGroups", "TourPrice");
        }
    }
}
