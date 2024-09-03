namespace Trixx_CafeSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editInit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salaries", "staffID", "dbo.Staffs");
            DropPrimaryKey("dbo.Salaries");
            AddColumn("dbo.Salaries", "salaryID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Salaries", "salaryID");
            AddForeignKey("dbo.Salaries", "staffID", "dbo.Staffs", "Staff_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "staffID", "dbo.Staffs");
            DropPrimaryKey("dbo.Salaries");
            DropColumn("dbo.Salaries", "salaryID");
            AddPrimaryKey("dbo.Salaries", "staffID");
            AddForeignKey("dbo.Salaries", "staffID", "dbo.Staffs", "Staff_ID");
        }
    }
}
