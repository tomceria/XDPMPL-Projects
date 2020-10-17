namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CMND", c => c.String());
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "Gender", c => c.String());
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "Gender");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "CMND");
        }
    }
}
