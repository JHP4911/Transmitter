namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Fields",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        ConditionType = c.Int(nullable: false),
                        Condition = c.String(),
                        SetDataFieldValue = c.String(),
                        DefaultFieldValue = c.String(),
                        UnitId = c.Guid(nullable: false),
                        FieldTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FieldTypes", t => t.FieldTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId)
                .Index(t => t.FieldTypeId);
            
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
                        FieldId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.SetDataFields",
                c => new
                    {
                        FieldId = c.Guid(nullable: false),
                        Value = c.String(),
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FieldId)
                .ForeignKey("dbo.Fields", t => t.FieldId)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.Guid(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.DashBoards",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FieldId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.FieldRegulations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FieldId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FieldRegulations", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.DashBoards", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fields", "UnitId", "dbo.Units");
            DropForeignKey("dbo.SetDataFields", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.Regulations", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.FieldValues", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.Fields", "FieldTypeId", "dbo.FieldTypes");
            DropForeignKey("dbo.Units", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FieldRegulations", new[] { "FieldId" });
            DropIndex("dbo.DashBoards", new[] { "FieldId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "CustomerId" });
            DropIndex("dbo.SetDataFields", new[] { "FieldId" });
            DropIndex("dbo.Regulations", new[] { "FieldId" });
            DropIndex("dbo.FieldValues", new[] { "FieldId" });
            DropIndex("dbo.Fields", new[] { "FieldTypeId" });
            DropIndex("dbo.Fields", new[] { "UnitId" });
            DropIndex("dbo.Units", new[] { "CustomerId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FieldRegulations");
            DropTable("dbo.DashBoards");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SetDataFields");
            DropTable("dbo.Regulations");
            DropTable("dbo.FieldValues");
            DropTable("dbo.FieldTypes");
            DropTable("dbo.Fields");
            DropTable("dbo.Units");
            DropTable("dbo.Customers");
        }
    }
}
