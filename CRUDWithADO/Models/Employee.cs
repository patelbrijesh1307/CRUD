using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDWithADO.Models
{
    public class Employee
    {
        [Display(Name= "ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Display(Name = "Age")]
        public int age { get; set; }
        [Required(ErrorMessage = "City is Required")]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Salary is Required")]
        [Display(Name = "Salary")]
        public int salary { get; set; }

    }
}