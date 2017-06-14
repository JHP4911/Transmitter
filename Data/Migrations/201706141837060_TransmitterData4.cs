namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegulationFields", "Regulation_Id", "dbo.Regulations");
            DropForeignKey("dbo.RegulationFields", "Field_Id", "dbo.Fields");
            DropIndex("dbo.RegulationFields", new[] { "Regulation_Id" });
            DropIndex("dbo.RegulationFields", new[] { "Field_Id" });
            DropTable("dbo.RegulationFields");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegulationFields",
                c => new
                    {
                        Regulation_Id = c.Guid(nullable: false),
                        Field_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Regulation_Id, t.Field_Id });
            
            CreateIndex("dbo.RegulationFields", "Field_Id");
            CreateIndex("dbo.RegulationFields", "Regulation_Id");
            AddForeignKey("dbo.RegulationFields", "Field_Id", "dbo.Fields", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RegulationFields", "Regulation_Id", "dbo.Regulations", "Id", cascadeDelete: true);
        }
    }
}
