namespace HouseHoldApp.RepositoryEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HouseHoldMembers", name: "User_Id", newName: "UserId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.HouseHoldMembers", name: "UserId", newName: "User_Id");
        }
    }
}
