using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarServices.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


        public string Message { get; set; }






    }
}