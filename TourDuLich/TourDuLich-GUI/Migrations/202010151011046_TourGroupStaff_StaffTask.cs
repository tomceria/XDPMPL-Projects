namespace TourDuLich_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TourGroupStaff_StaffTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourGroupStaffs", "StaffTask", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourGroupStaffs", "StaffTask");
        }
    }
}
