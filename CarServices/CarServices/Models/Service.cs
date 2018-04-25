using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarServices.Models
{
    public class Service
    {

        [Key]
        public int ServiceID { get; set; }

        public string ServiceName { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }




    }
}