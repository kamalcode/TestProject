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
        public string Brand { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Year of Manf")]
        public int Year { get; set; }

        [Display(Name = "Price")]
        public Decimal Price { get; set; }

        [Display(Name = "New")]
        public bool New { get; set; }

        public string CreatedBy { get; set; }
    }
}