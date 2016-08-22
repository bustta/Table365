namespace Table365.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inituserandphoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TablePhotoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(maxLength: 256),
                        Location = c.String(),
                        PostTime = c.DateTime(nullable: false),
                        Photo = c.Binary(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Account = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        RegisterTime = c.DateTime(nullable: false),
                        LoginTime = c.DateTime(nullable: false),
                        ProfilePhoto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TablePhotoes", "User_Id", "dbo.Users");
            DropIndex("dbo.TablePhotoes", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.TablePhotoes");
        }
    }
}
