using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_DAL.Models
{
    public class StudentModel
    {
        [Display(Name ="Student ID")]
        public int studentID { get; set; }

        [Display(Name ="Student Name")]
        [Required(ErrorMessage ="*")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Too short name")]
        public string studentname { get; set; }

        [Display(Name ="Student Email")]
        [Required(ErrorMessage ="*")]
        [EmailAddress(ErrorMessage ="Invalid Format")]
        public string studentemailid { get; set; }

        [Display(Name ="Student password")]
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string studentpassword { get; set; }

        [Display(Name="Student Mobileno")]
        [Required(ErrorMessage ="*")]
        [RegularExpression("^[7-9][0-9]{9}$",ErrorMessage ="Invalid Number")]
        public string studentmobileno { get; set; }

        [Display(Name = "Student city")]
        [Required(ErrorMessage = "*")]
        public string studentcity { get; set; }

        [Display(Name = "Student gender")]
        [Required(ErrorMessage = "*")]
        public string studentgender { get; set; }
        public string studentimageaddress { get; set; }

        [Display(Name ="Student Image")]
        [Required(ErrorMessage ="*")]
        public HttpPostedFileBase studentimagefile { get; set; }
    }
}