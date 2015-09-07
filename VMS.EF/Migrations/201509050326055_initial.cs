namespace VMS.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Email = c.Int(nullable: false),
                        SMS = c.Int(nullable: false),
                        Designation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpID);
            
            CreateTable(
                "dbo.InOuts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VisitorID = c.Int(nullable: false),
                        InTime = c.String(),
                        OutTime = c.String(),
                        Status = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        VisitorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        IdCard = c.String(),
                        Vehicle = c.String(),
                        VehicleNu = c.String(),
                        Color = c.String(),
                        ParkineZone = c.String(),
                        Building = c.String(),
                        MeeTTo = c.String(),
                        TokenNo = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        Guests = c.String(),
                        VisitorPic = c.String(),
                    })
                .PrimaryKey(t => t.VisitorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visitors");
            DropTable("dbo.InOuts");
            DropTable("dbo.Employees");
        }
    }
}
