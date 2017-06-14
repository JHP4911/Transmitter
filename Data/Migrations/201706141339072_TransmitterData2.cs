namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regulations", "Field_Id", "dbo.Fields");
            DropForeignKey("dbo.SetDataFields", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.FieldRegulations", "FieldId", "dbo.Fields");
            DropIndex("dbo.Regulations", new[] { "Field_Id" });
            DropIndex("dbo.SetDataFields", new[] { "FieldId" });
            DropIndex("dbo.FieldRegulations", new[] { "FieldId" });
            CreateTable(
                "dbo.RegulationFields",
                c => new
                    {
                        Regulation_Id = c.Guid(nullable: false),
                        Field_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Regulation_Id, t.Field_Id })
                .ForeignKey("dbo.Regulations", t => t.Regulation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Fields", t => t.Field_Id, cascadeDelete: true)
                .Index(t => t.Regulation_Id)
                .Index(t => t.Field_Id);
            
            DropColumn("dbo.Regulations", "Field_Id");
            DropTable("dbo.SetDataFields");
            DropTable("dbo.FieldRegulations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FieldRegulations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FieldId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SetDataFields",
                c => new
                    {
                        FieldId = c.Guid(nullable: false),
                        Value = c.String(),
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FieldId);
            
            AddColumn("dbo.Regulations", "Field_Id", c => c.Guid());
            DropForeignKey("dbo.RegulationFields", "Field_Id", "dbo.Fields");
            DropForeignKey("dbo.RegulationFields", "Regulation_Id", "dbo.Regulations");
            DropIndex("dbo.RegulationFields", new[] { "Field_Id" });
            DropIndex("dbo.RegulationFields", new[] { "Regulation_Id" });
            DropTable("dbo.RegulationFields");
            CreateIndex("dbo.FieldRegulations", "FieldId");
            CreateIndex("dbo.SetDataFields", "FieldId");
            CreateIndex("dbo.Regulations", "Field_Id");
            AddForeignKey("dbo.FieldRegulations", "FieldId", "dbo.Fields", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SetDataFields", "FieldId", "dbo.Fields", "Id");
            AddForeignKey("dbo.Regulations", "Field_Id", "dbo.Fields", "Id");
        }
    }
}
