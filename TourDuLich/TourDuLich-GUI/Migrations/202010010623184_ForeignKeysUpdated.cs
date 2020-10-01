namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TourPrices", "Tour_ID", "dbo.Tours");
            DropIndex("dbo.TourPrices", new[] { "Tour_ID" });
            RenameColumn(table: "dbo.TourPrices", name: "Tour_ID", newName: "TourID");
            RenameColumn(table: "dbo.Tours", name: "TourType_ID", newName: "TourTypeID");
            RenameIndex(table: "dbo.Tours", name: "IX_TourType_ID", newName: "IX_TourTypeID");
            AlterColumn("dbo.TourPrices", "TourID", c => c.Int(nullable: false));
            CreateIndex("dbo.TourPrices", "TourID");
            AddForeignKey("dbo.TourPrices", "TourID", "dbo.Tours", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourPrices", "TourID", "dbo.Tours");
            DropIndex("dbo.TourPrices", new[] { "TourID" });
            AlterColumn("dbo.TourPrices", "TourID", c => c.Int());
            RenameIndex(table: "dbo.Tours", name: "IX_TourTypeID", newName: "IX_TourType_ID");
            RenameColumn(table: "dbo.Tours", name: "TourTypeID", newName: "TourType_ID");
            RenameColumn(table: "dbo.TourPrices", name: "TourID", newName: "Tour_ID");
            CreateIndex("dbo.TourPrices", "Tour_ID");
            AddForeignKey("dbo.TourPrices", "Tour_ID", "dbo.Tours", "ID");
        }
    }
}
