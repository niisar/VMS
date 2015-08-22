namespace VMS.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
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
            
            DropColumn("dbo.Visitors", "InTime");
            DropColumn("dbo.Visitors", "OutTime");
            DropColumn("dbo.Visitors", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visitors", "Status", c => c.String());
            AddColumn("dbo.Visitors", "OutTime", c => c.String());
            AddColumn("dbo.Visitors", "InTime", c => c.String());
            DropTable("dbo.InOuts");
        }
    }
}
