﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeMVCcoreCRUD.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, ErrorMessage = "Max Length of username is 15")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "UserPassword is required")]
        public string UserPassword { get; set; }
        //public string Title { get; set; }
    }
}
