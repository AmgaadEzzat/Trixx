namespace Trixx_CafeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        BillDate = c.DateTime(nullable: false, storeType: "date"),
                        BillTime = c.Time(nullable: false, precision: 7),
                        CashierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.Login_User", t => t.CashierID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CashierID);
            
            CreateTable(
                "dbo.Login_User",
                c => new
                    {
                        User_ID = c.Int(nullable: false, identity: true),
                        User_Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.User_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Order_Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Order_Id)
                .ForeignKey("dbo.Login_User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        AmountPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_ID = c.Int(nullable: false, identity: true),
                        User_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                        Stock_Qty = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Product_ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .ForeignKey("dbo.Login_User", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Category_ID);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        staffID = c.Int(nullable: false),
                        Wage_per_hour = c.Double(nullable: false),
                        Start_Time = c.Time(nullable: false, precision: 7),
                        End_Time = c.Time(nullable: false, precision: 7),
                        Salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.staffID)
                .ForeignKey("dbo.Staffs", t => t.staffID)
                .Index(t => t.staffID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Staff_ID = c.Int(nullable: false, identity: true),
                        Staff_Name = c.String(),
                        User_ID = c.Int(nullable: false),
                        NID = c.String(maxLength: 14, unicode: false),
                        Address = c.String(),
                        Assign_Date = c.DateTime(nullable: false, storeType: "date"),
                        Staff_Phone = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.Staff_ID)
                .ForeignKey("dbo.Login_User", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "staffID", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "User_ID", "dbo.Login_User");
            DropForeignKey("dbo.Bills", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "User_ID", "dbo.Login_User");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Login_User");
            DropForeignKey("dbo.Bills", "CashierID", "dbo.Login_User");
            DropIndex("dbo.Staffs", new[] { "User_ID" });
            DropIndex("dbo.Salaries", new[] { "staffID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Products", new[] { "User_ID" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Bills", new[] { "CashierID" });
            DropIndex("dbo.Bills", new[] { "OrderId" });
            DropTable("dbo.Staffs");
            DropTable("dbo.Salaries");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.Login_User");
            DropTable("dbo.Bills");
        }
    }
}
