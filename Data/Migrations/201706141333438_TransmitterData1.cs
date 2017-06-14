namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regulations", "FieldId", "dbo.Fields");
            DropIndex("dbo.Regulations", new[] { "FieldId" });
            RenameColumn(table: "dbo.Regulations", name: "FieldId", newName: "Field_Id");
            AlterColumn("dbo.Regulations", "Field_Id", c => c.Guid());
            CreateIndex("dbo.Regulations", "Field_Id");
            AddForeignKey("dbo.Regulations", "Field_Id", "dbo.Fields", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regulations", "Field_Id", "dbo.Fields");
            DropIndex("dbo.Regulations", new[] { "Field_Id" });
            AlterColumn("dbo.Regulations", "Field_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Regulations", name: "Field_Id", newName: "FieldId");
            CreateIndex("dbo.Regulations", "FieldId");
            AddForeignKey("dbo.Regulations", "FieldId", "dbo.Fields", "Id", cascadeDelete: true);
        }
    }
}
