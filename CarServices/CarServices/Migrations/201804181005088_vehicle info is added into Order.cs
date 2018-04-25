namespace CarServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleinfoisaddedintoOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceOrders", "VehicleCompany", c => c.String());
            AddColumn("dbo.ServiceOrders", "VehicleModel", c => c.String());
            DropColumn("dbo.ServiceOrders", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceOrders", "Email", c => c.String());
            DropColumn("dbo.ServiceOrders", "VehicleModel");
            DropColumn("dbo.ServiceOrders", "VehicleCompany");
        }
    }
}
