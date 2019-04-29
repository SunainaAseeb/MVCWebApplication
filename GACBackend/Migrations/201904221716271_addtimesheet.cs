namespace GACBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtimesheet : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.TimeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.Int(nullable: false),
                        Sunday = c.Int(nullable: false),
                        Monday = c.Int(nullable: false),
                        Tuesday = c.Int(nullable: false),
                        Wednesday = c.Int(nullable: false),
                        Thursday = c.Int(nullable: false),
                        Friday = c.Int(nullable: false),
                        Saturday = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Code, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Name, cascadeDelete: true)
                .Index(t => t.Code)
                .Index(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeDetails", "Name", "dbo.Tasks");
            DropForeignKey("dbo.TimeDetails", "Code", "dbo.Employees");
            DropIndex("dbo.TimeDetails", new[] { "Name" });
            DropIndex("dbo.TimeDetails", new[] { "Code" });
            DropIndex("dbo.Tasks", "Ix_Name");
            DropIndex("dbo.Employees", new[] { "Code" });
            DropTable("dbo.TimeDetails");
            DropTable("dbo.Tasks");
            DropTable("dbo.Employees");
        }
    }
}
