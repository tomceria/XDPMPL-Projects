namespace TechShop_Manager.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class TourDBv1 : DbMigration
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
                "dbo.TourGroupCosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourGroupID = c.Int(nullable: false),
                        CostTypeID = c.Int(nullable: false),
                        Value = c.Long(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CostTypes", t => t.CostTypeID)
                .ForeignKey("dbo.TourGroups", t => t.TourGroupID)
                .Index(t => t.TourGroupID)
                .Index(t => t.CostTypeID);
            
            CreateTable(
                "dbo.TourGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        PriceGroup = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tours", t => t.TourID)
                .Index(t => t.TourID);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PriceRef = c.Long(nullable: false),
                        TourTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TourTypes", t => t.TourTypeID)
                .Index(t => t.TourTypeID);
            
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
                .ForeignKey("dbo.Destinations", t => t.DestinationID)
                .ForeignKey("dbo.Tours", t => t.TourID)
                .Index(t => t.TourID)
                .Index(t => t.DestinationID);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TourPrices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourID = c.Int(nullable: false),
                        Value = c.Long(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tours", t => t.TourID, cascadeDelete: true)
                .Index(t => t.TourID);
            
            CreateTable(
                "dbo.TourTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.TourGroups", t => t.TourGroupID)
                .Index(t => t.TourGroupID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CMND = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TourGroupStaffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TourGroupID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                        StaffTask = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Staffs", t => t.StaffID)
                .ForeignKey("dbo.TourGroups", t => t.TourGroupID)
                .Index(t => t.TourGroupID)
                .Index(t => t.StaffID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourGroupCosts", "TourGroupID", "dbo.TourGroups");
            DropForeignKey("dbo.TourGroupStaffs", "TourGroupID", "dbo.TourGroups");
            DropForeignKey("dbo.TourGroupStaffs", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.TourGroupDetails", "TourGroupID", "dbo.TourGroups");
            DropForeignKey("dbo.TourGroupDetails", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.TourGroups", "TourID", "dbo.Tours");
            DropForeignKey("dbo.Tours", "TourTypeID", "dbo.TourTypes");
            DropForeignKey("dbo.TourPrices", "TourID", "dbo.Tours");
            DropForeignKey("dbo.TourDetails", "TourID", "dbo.Tours");
            DropForeignKey("dbo.TourDetails", "DestinationID", "dbo.Destinations");
            DropForeignKey("dbo.TourGroupCosts", "CostTypeID", "dbo.CostTypes");
            DropIndex("dbo.TourGroupStaffs", new[] { "StaffID" });
            DropIndex("dbo.TourGroupStaffs", new[] { "TourGroupID" });
            DropIndex("dbo.TourGroupDetails", new[] { "CustomerID" });
            DropIndex("dbo.TourGroupDetails", new[] { "TourGroupID" });
            DropIndex("dbo.TourPrices", new[] { "TourID" });
            DropIndex("dbo.TourDetails", new[] { "DestinationID" });
            DropIndex("dbo.TourDetails", new[] { "TourID" });
            DropIndex("dbo.Tours", new[] { "TourTypeID" });
            DropIndex("dbo.TourGroups", new[] { "TourID" });
            DropIndex("dbo.TourGroupCosts", new[] { "CostTypeID" });
            DropIndex("dbo.TourGroupCosts", new[] { "TourGroupID" });
            DropTable("dbo.Staffs");
            DropTable("dbo.TourGroupStaffs");
            DropTable("dbo.Customers");
            DropTable("dbo.TourGroupDetails");
            DropTable("dbo.TourTypes");
            DropTable("dbo.TourPrices");
            DropTable("dbo.Destinations");
            DropTable("dbo.TourDetails");
            DropTable("dbo.Tours");
            DropTable("dbo.TourGroups");
            DropTable("dbo.TourGroupCosts");
            DropTable("dbo.CostTypes");
        }
    }
}
