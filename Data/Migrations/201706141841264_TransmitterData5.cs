namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegulationFields",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FieldId = c.Guid(nullable: false),
                        RegulationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .ForeignKey("dbo.Regulations", t => t.RegulationId, cascadeDelete: true)
                .Index(t => t.FieldId)
                .Index(t => t.RegulationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegulationFields", "RegulationId", "dbo.Regulations");
            DropForeignKey("dbo.RegulationFields", "FieldId", "dbo.Fields");
            DropIndex("dbo.RegulationFields", new[] { "RegulationId" });
            DropIndex("dbo.RegulationFields", new[] { "FieldId" });
            DropTable("dbo.RegulationFields");
        }
    }
}
