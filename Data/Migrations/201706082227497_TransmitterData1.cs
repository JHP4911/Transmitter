namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SetDataFields");
            AddColumn("dbo.SetDataFields", "FieldId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.SetDataFields", "FieldId");
            CreateIndex("dbo.SetDataFields", "FieldId");
            AddForeignKey("dbo.SetDataFields", "FieldId", "dbo.Fields", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SetDataFields", "FieldId", "dbo.Fields");
            DropIndex("dbo.SetDataFields", new[] { "FieldId" });
            DropPrimaryKey("dbo.SetDataFields");
            DropColumn("dbo.SetDataFields", "FieldId");
            AddPrimaryKey("dbo.SetDataFields", "Id");
        }
    }
}
