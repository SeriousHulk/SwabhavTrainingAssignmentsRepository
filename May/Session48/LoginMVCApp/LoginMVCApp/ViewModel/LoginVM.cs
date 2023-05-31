using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginMVCApp.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Username is required")]
        [StringLength(5,ErrorMessage ="Max Length of username is 5")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "UserPassword is required")]
        public string UserPassword { get; set; }
        public string Title { get; set; }
    }
}