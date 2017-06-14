namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransmitterData4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DashBoards",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FieldId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Fields", "DashBoard_Id", c => c.Guid());
            CreateIndex("dbo.Fields", "DashBoard_Id");
            AddForeignKey("dbo.Fields", "DashBoard_Id", "dbo.DashBoards", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fields", "DashBoard_Id", "dbo.DashBoards");
            DropIndex("dbo.Fields", new[] { "DashBoard_Id" });
            DropColumn("dbo.Fields", "DashBoard_Id");
            DropTable("dbo.DashBoards");
        }
    }
}
