namespace MvcProject1257883.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Date = c.DateTime(nullable: false),
                        ImageName = c.String(),
                        ImageURL = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(),
                        DevisionHead = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        UserId = c.Int(nullable: false),
                        TblUsers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.TblUsers_Id)
                .Index(t => t.TblUsers_Id);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRoles", "TblUsers_Id", "dbo.tblUsers");
            DropForeignKey("dbo.Customers", "DistrictId", "dbo.Districts");
            DropIndex("dbo.tblRoles", new[] { "TblUsers_Id" });
            DropIndex("dbo.Customers", new[] { "DistrictId" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblRoles");
            DropTable("dbo.Divisions");
            DropTable("dbo.Districts");
            DropTable("dbo.Customers");
        }
    }
}
