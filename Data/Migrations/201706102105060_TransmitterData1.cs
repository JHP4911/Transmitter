namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FieldRegulations", "Condition", c => c.String());
            AddColumn("dbo.FieldRegulations", "DefaultFieldValue", c => c.String());
            DropColumn("dbo.FieldRegulations", "ConditionValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FieldRegulations", "ConditionValue", c => c.String());
            DropColumn("dbo.FieldRegulations", "DefaultFieldValue");
            DropColumn("dbo.FieldRegulations", "Condition");
        }
    }
}
