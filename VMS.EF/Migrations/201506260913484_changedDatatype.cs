namespace VMS.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visitors", "EntryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitors", "EntryDate", c => c.String());
        }
    }
}
