using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViewModelLayer.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Display(Name = "Number Of Days")]
        [Required]
        public int NumberOfDays { get; set; }
    }
}