using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_DAL.Models
{
    public class StudentProjectionModel
    {
        [Display(Name ="Student id")]
        public int studentid { get; set; }
        [Display(Name = "student name")]
        public string studentname { get; set; }
        [Display(Name = "student gender")]
        public string studentgender { get; set; }
        [Display(Name = "student image")]
        public string studentimageaddress { get; set; }



    }
}