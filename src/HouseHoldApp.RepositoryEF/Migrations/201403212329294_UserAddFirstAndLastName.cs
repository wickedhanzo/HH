namespace HouseHoldApp.RepositoryEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddFirstAndLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IdentityUsers", "FirstName", c => c.String());
            AddColumn("dbo.IdentityUsers", "LastName", c => c.String());
            DropColumn("dbo.IdentityUsers", "EmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IdentityUsers", "EmailAddress", c => c.String());
            DropColumn("dbo.IdentityUsers", "LastName");
            DropColumn("dbo.IdentityUsers", "FirstName");
        }
    }
}
