namespace VMS.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_field_added_to_visitors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visitors", "Guests", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visitors", "Guests");
        }
    }
}
