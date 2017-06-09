namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.FieldRegulations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FieldId = c.Guid(nullable: false),
                        RegulationId = c.Guid(nullable: false),
                        ConditionType = c.Int(nullable: false),
                        ConditionValue = c.String(),
                        SetDataFieldValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .ForeignKey("dbo.Regulations", t => t.RegulationId, cascadeDelete: true)
                .Index(t => t.FieldId)
                .Index(t => t.RegulationId);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        UnitId = c.Guid(nullable: false),
                        TypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FieldTypes", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.FieldTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FieldValues",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FieldId = c.Guid(nullable: false),
                        Value = c.String(),
                        CreateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.Regulations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SetDataFields",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Name", c => c.String());
            AddColumn("dbo.Customers", "Phone", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropColumn("dbo.Customers", "CreateUser");
            DropColumn("dbo.Customers", "CreateDate");
            DropColumn("dbo.Customers", "CreateTime");
            DropColumn("dbo.Customers", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "CreateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Customers", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Customers", "CreateUser", c => c.String());
            DropForeignKey("dbo.FieldRegulations", "RegulationId", "dbo.Regulations");
            DropForeignKey("dbo.FieldRegulations", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.Fields", "UnitId", "dbo.Units");
            DropForeignKey("dbo.FieldValues", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.Fields", "TypeId", "dbo.FieldTypes");
            DropForeignKey("dbo.Units", "CustomerId", "dbo.Customers");
            DropIndex("dbo.FieldValues", new[] { "FieldId" });
            DropIndex("dbo.Fields", new[] { "TypeId" });
            DropIndex("dbo.Fields", new[] { "UnitId" });
            DropIndex("dbo.FieldRegulations", new[] { "RegulationId" });
            DropIndex("dbo.FieldRegulations", new[] { "FieldId" });
            DropIndex("dbo.Units", new[] { "CustomerId" });
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "Name");
            DropTable("dbo.SetDataFields");
            DropTable("dbo.Regulations");
            DropTable("dbo.FieldValues");
            DropTable("dbo.FieldTypes");
            DropTable("dbo.Fields");
            DropTable("dbo.FieldRegulations");
            DropTable("dbo.Units");
        }
    }
}
