namespace level.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFiledDesctiption2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "TestDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "TestDescription");
        }
    }
}
