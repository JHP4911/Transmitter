namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Fields", name: "TypeId", newName: "FieldTypeId");
            RenameIndex(table: "dbo.Fields", name: "IX_TypeId", newName: "IX_FieldTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Fields", name: "IX_FieldTypeId", newName: "IX_TypeId");
            RenameColumn(table: "dbo.Fields", name: "FieldTypeId", newName: "TypeId");
        }
    }
}
