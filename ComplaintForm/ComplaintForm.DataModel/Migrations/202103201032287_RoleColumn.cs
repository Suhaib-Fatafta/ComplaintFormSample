namespace ComplaintForm.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("COMPLAINTS.USER", "ROLE", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("COMPLAINTS.USER", "ROLE");
        }
    }
}
