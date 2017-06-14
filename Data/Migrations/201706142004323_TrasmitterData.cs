namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrasmitterData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fields", "CheckValue", c => c.String());
            DropColumn("dbo.Fields", "SetDataFieldValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fields", "SetDataFieldValue", c => c.String());
            DropColumn("dbo.Fields", "CheckValue");
        }
    }
}
