namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CustomerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CustomerId");
            AddForeignKey("dbo.AspNetUsers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AspNetUsers", new[] { "CustomerId" });
            DropColumn("dbo.AspNetUsers", "CustomerId");
        }
    }
}
