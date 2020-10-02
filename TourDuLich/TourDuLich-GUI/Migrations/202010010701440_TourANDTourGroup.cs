namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TourANDTourGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourGroups", "TourID", c => c.Int(nullable: false));
            CreateIndex("dbo.TourGroups", "TourID");
            AddForeignKey("dbo.TourGroups", "TourID", "dbo.Tours", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourGroups", "TourID", "dbo.Tours");
            DropIndex("dbo.TourGroups", new[] { "TourID" });
            DropColumn("dbo.TourGroups", "TourID");
        }
    }
}
