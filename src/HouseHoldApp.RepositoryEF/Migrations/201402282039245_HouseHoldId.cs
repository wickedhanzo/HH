namespace HouseHoldApp.RepositoryEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HouseHoldId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HouseHoldMembers", "HouseHold_Id", "dbo.HouseHolds");
            DropIndex("dbo.HouseHoldMembers", new[] { "HouseHold_Id" });
            RenameColumn(table: "dbo.HouseHoldMembers", name: "HouseHold_Id", newName: "HouseHoldId");
            AlterColumn("dbo.HouseHoldMembers", "HouseHoldId", c => c.Int(nullable: false));
            CreateIndex("dbo.HouseHoldMembers", "HouseHoldId");
            AddForeignKey("dbo.HouseHoldMembers", "HouseHoldId", "dbo.HouseHolds", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseHoldMembers", "HouseHoldId", "dbo.HouseHolds");
            DropIndex("dbo.HouseHoldMembers", new[] { "HouseHoldId" });
            AlterColumn("dbo.HouseHoldMembers", "HouseHoldId", c => c.Int());
            RenameColumn(table: "dbo.HouseHoldMembers", name: "HouseHoldId", newName: "HouseHold_Id");
            CreateIndex("dbo.HouseHoldMembers", "HouseHold_Id");
            AddForeignKey("dbo.HouseHoldMembers", "HouseHold_Id", "dbo.HouseHolds", "Id");
        }
    }
}
