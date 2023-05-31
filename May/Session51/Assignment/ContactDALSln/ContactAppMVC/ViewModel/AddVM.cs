using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactAppMVC.ViewModel
{
    public class AddVM
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(10, ErrorMessage = "Max Length of username is 10")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }

        public string Title { get; set; }
    }
}