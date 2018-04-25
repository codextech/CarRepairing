using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarServices.Models
{
    public class ServiceOrder
    {
        [Key]
        public int ServiceOrderID { get; set; }

        public string Name { get; set; }


        public string Mobile { get; set; }

        public string Location { get; set; }

        public string VehicleCompany { get; set; }
        public string VehicleModel { get; set; }



        public int ServiceID { get; set; }

        public int EmployeeId { get; set; }


        // Navigation property - Helps in View

        public virtual Service Service { get; set; }

        public virtual Employee Employee { get; set; }


        //public ServiceOrder()
        //{
        //    EmployeeId = 1;
        //}



    }
}