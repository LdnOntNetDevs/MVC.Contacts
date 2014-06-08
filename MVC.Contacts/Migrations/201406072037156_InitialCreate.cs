namespace MVC.Contacts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(),
                        Twitter = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.ContactPhones",
                c => new
                    {
                        ContactPhoneId = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactPhoneId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactPhones", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactPhones", new[] { "ContactId" });
            DropTable("dbo.ContactPhones");
            DropTable("dbo.Contacts");
        }
    }
}
