namespace HouseHoldApp.RepositoryEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserImages", "User_Id", "dbo.IdentityUsers");
            DropIndex("dbo.UserImages", new[] { "User_Id" });
            DropColumn("dbo.IdentityUsers", "UserImageId");
            DropTable("dbo.UserImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Image = c.Binary(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentityUsers", "UserImageId", c => c.Int());
            CreateIndex("dbo.UserImages", "User_Id");
            AddForeignKey("dbo.UserImages", "User_Id", "dbo.IdentityUsers", "Id");
        }
    }
}
