using SimpleMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVCApp.ViewModels
{
    public class GetStudentCollageVM
    {
        public List<Student> Students { get; set; }
        public List<Collage> Collages { get; set; }
    }
}