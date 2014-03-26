namespace HouseHoldApp.RepositoryEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderToUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentityUsers", "GenderId", c => c.Int());
            CreateIndex("dbo.IdentityUsers", "GenderId");
            AddForeignKey("dbo.IdentityUsers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUsers", "GenderId", "dbo.Genders");
            DropIndex("dbo.IdentityUsers", new[] { "GenderId" });
            DropColumn("dbo.IdentityUsers", "GenderId");
            DropTable("dbo.Genders");
        }
    }
}
