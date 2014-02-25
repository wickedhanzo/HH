namespace HouseHoldApp.RepositoryEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HouseHolds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HouseHoldMembers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HouseHold_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.HouseHolds", t => t.HouseHold_Id)
                .Index(t => t.Id)
                .Index(t => t.HouseHold_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseHoldMembers", "HouseHold_Id", "dbo.HouseHolds");
            DropForeignKey("dbo.HouseHoldMembers", "Id", "dbo.Users");
            DropIndex("dbo.HouseHoldMembers", new[] { "HouseHold_Id" });
            DropIndex("dbo.HouseHoldMembers", new[] { "Id" });
            DropTable("dbo.HouseHoldMembers");
            DropTable("dbo.HouseHolds");
            DropTable("dbo.Users");
        }
    }
}
