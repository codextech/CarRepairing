namespace CarServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkEmplyeewithsericeorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeSkill = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        CNIC = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            AddColumn("dbo.ServiceOrders", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceOrders", "EmployeeId");
            AddForeignKey("dbo.ServiceOrders", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceOrders", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ServiceOrders", new[] { "EmployeeId" });
            DropColumn("dbo.ServiceOrders", "EmployeeId");
            DropTable("dbo.Employees");
        }
    }
}
