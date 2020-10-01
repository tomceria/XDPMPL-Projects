namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NavigationPropertyFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourGroups", "TourGroup_ID", c => c.Int());
            CreateIndex("dbo.TourGroups", "TourGroup_ID");
            AddForeignKey("dbo.TourGroups", "TourGroup_ID", "dbo.TourGroups", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourGroups", "TourGroup_ID", "dbo.TourGroups");
            DropIndex("dbo.TourGroups", new[] { "TourGroup_ID" });
            DropColumn("dbo.TourGroups", "TourGroup_ID");
        }
    }
}
