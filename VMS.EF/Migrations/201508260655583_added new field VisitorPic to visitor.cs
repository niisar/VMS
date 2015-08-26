namespace VMS.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewfieldVisitorPictovisitor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "VisitorPic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visitors", "VisitorPic");
        }
    }
}
