using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace restauranter.Models
{
    public class Review
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Reviewer Name is required")]
        public string Reviewer { get; set; }

        [Required(ErrorMessage = "Restaurant Name is required")]
        public string Restaurant { get; set;}

        [Required(ErrorMessage = "Stars are required")]
        public int Stars { get; set; }

        [Required(ErrorMessage = "Review is required")]
        [MinLength(10, ErrorMessage = "Review needs at least 10 characters")]
        public string Reviews { get; set; }

        [Required(ErrorMessage = "Visit Date is required")]
        [NotFutureDate(ErrorMessage="Date cannot be in the future.")]
        [DataType(DataType.DateTime)]
        public DateTime Visit_Date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_At { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Updated_At { get; set; }


    }
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime)value <= DateTime.Now;
        }
    }
    
}