namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CostTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TourDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        TourID = c.Int(nullable: false),
                        DestinationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: true)
                .ForeignKey("dbo.Tours", t => t.TourID, cascadeDelete: true)
                .Index(t => t.TourID)
                .Index(t => t.DestinationID);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PriceRef = c.Long(nullable: false),
                        TourType_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TourTypes", t => t.TourType_ID, cascadeDelete: true)
                .Index(t => t.TourType_ID);
            
            CreateTable(
                "dbo.TourPrices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Long(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                        Tour_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tours", t => t.Tour_ID)
                .Index(t => t.Tour_ID);
            
            CreateTable(
                "dbo.TourTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TourGroupCosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourGroupID = c.Int(nullable: false),
                        CostTypeID = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CostTypes", t => t.CostTypeID, cascadeDelete: true)
                .ForeignKey("dbo.TourGroups", t => t.TourGroupID, cascadeDelete: true)
                .Index(t => t.TourGroupID)
                .Index(t => t.CostTypeID);
            
            CreateTable(
                "dbo.TourGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        PriceGroup = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TourGroupDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourGroupID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.TourGroups", t => t.TourGroupID, cascadeDelete: true)
                .Index(t => t.TourGroupID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.TourGroupStaffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourGroupID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .ForeignKey("dbo.TourGroups", t => t.TourGroupID, cascadeDelete: true)
                .Index(t => t.TourGroupID)
                .Index(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourGroupStaffs", "TourGroupID", "dbo.TourGroups");
            DropForeignKey("dbo.TourGroupStaffs", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.TourGroupDetails", "TourGroupID", "dbo.TourGroups");
            DropForeignKey("dbo.TourGroupDetails", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.TourGroupCosts", "TourGroupID", "dbo.TourGroups");
            DropForeignKey("dbo.TourGroupCosts", "CostTypeID", "dbo.CostTypes");
            DropForeignKey("dbo.TourDetails", "TourID", "dbo.Tours");
            DropForeignKey("dbo.Tours", "TourType_ID", "dbo.TourTypes");
            DropForeignKey("dbo.TourPrices", "Tour_ID", "dbo.Tours");
            DropForeignKey("dbo.TourDetails", "DestinationID", "dbo.Destinations");
            DropIndex("dbo.TourGroupStaffs", new[] { "StaffID" });
            DropIndex("dbo.TourGroupStaffs", new[] { "TourGroupID" });
            DropIndex("dbo.TourGroupDetails", new[] { "CustomerID" });
            DropIndex("dbo.TourGroupDetails", new[] { "TourGroupID" });
            DropIndex("dbo.TourGroupCosts", new[] { "CostTypeID" });
            DropIndex("dbo.TourGroupCosts", new[] { "TourGroupID" });
            DropIndex("dbo.TourPrices", new[] { "Tour_ID" });
            DropIndex("dbo.Tours", new[] { "TourType_ID" });
            DropIndex("dbo.TourDetails", new[] { "DestinationID" });
            DropIndex("dbo.TourDetails", new[] { "TourID" });
            DropTable("dbo.TourGroupStaffs");
            DropTable("dbo.TourGroupDetails");
            DropTable("dbo.TourGroups");
            DropTable("dbo.TourGroupCosts");
            DropTable("dbo.TourTypes");
            DropTable("dbo.TourPrices");
            DropTable("dbo.Tours");
            DropTable("dbo.TourDetails");
            DropTable("dbo.Staffs");
            DropTable("dbo.Destinations");
            DropTable("dbo.Customers");
            DropTable("dbo.CostTypes");
        }
    }
}
