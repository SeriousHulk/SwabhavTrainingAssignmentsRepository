using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml.Linq;

namespace CustomAnnotationPOC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [ValidateBirthDate(ErrorMessage = "DOB Should be between 01-01-1990 & 01-01-2000")]
        public DateTime Birthdate { get; set; }
    }
}