using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactWebAPI.Models
{
    public class ContactDTO
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
    }
}