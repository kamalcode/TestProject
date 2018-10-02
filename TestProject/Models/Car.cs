using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Please Enter Brand")]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Please Enter Model")]
        public string Model { get; set; }

        [Display(Name = "Year")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        public int Year { get; set; }

        [Display(Name = "Price")]
        public Decimal Price { get; set; }

        [Display(Name = "New")]
        public bool New { get; set; }

        public string CreatedBy { get; set; }
    }
}