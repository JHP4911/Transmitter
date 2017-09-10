namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transmitter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fields", "SetDataFieldValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fields", "SetDataFieldValue");
        }
    }
}
