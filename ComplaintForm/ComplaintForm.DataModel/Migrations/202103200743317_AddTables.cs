namespace ComplaintForm.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "COMPLAINTS.COMPLAINTS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        COMPLAINT_TYPE = c.String(maxLength: 200),
                        FORM_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("COMPLAINTS.USER_FORMS", t => t.FORM_ID)
                .Index(t => t.FORM_ID);
            
            CreateTable(
                "COMPLAINTS.USER_FORMS",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        USER_NAME = c.String(nullable: false, maxLength: 100),
                        COMPLAINT_TITLE = c.String(nullable: false, maxLength: 100),
                        IS_RECURRING = c.String(nullable: false, maxLength: 50),
                        COMPLAINT_DETAILS = c.String(nullable: false),
                        LOG_DATE = c.DateTime(nullable: false),
                        STATUS_ID = c.Int(nullable: false),
                        USER_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("COMPLAINTS.USER", t => t.USER_ID)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "COMPLAINTS.USER",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FULL_NAME = c.String(nullable: false, maxLength: 100),
                        PASSWORD = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("COMPLAINTS.USER_FORMS", "USER_ID", "COMPLAINTS.USER");
            DropForeignKey("COMPLAINTS.COMPLAINTS", "FORM_ID", "COMPLAINTS.USER_FORMS");
            DropIndex("COMPLAINTS.USER_FORMS", new[] { "USER_ID" });
            DropIndex("COMPLAINTS.COMPLAINTS", new[] { "FORM_ID" });
            DropTable("COMPLAINTS.USER");
            DropTable("COMPLAINTS.USER_FORMS");
            DropTable("COMPLAINTS.COMPLAINTS");
        }
    }
}
