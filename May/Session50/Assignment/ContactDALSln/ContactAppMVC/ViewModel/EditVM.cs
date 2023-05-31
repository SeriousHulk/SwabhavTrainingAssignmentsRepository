using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactAppMVC.ViewModel
{
    public class EditVM
    {
        public int Id { get; set; }
        [StringLength(10, ErrorMessage = "Max Length of username is 10")]
        public string Name { get; set; }
        [StringLength(10, ErrorMessage = "Max Length of Mobile No. is 10")]
        public string Mobile { get; set; }

        public string Title { get; set; }
    }
}