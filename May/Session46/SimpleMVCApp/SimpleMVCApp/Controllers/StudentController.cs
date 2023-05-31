using SimpleMVCApp.Models;
using SimpleMVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult GetStudent()
        {
            Student student = new Student
            {
                Id = 1,
                Name = "Vikrant",
                Cgpa = 8
            };
            return View(student);
        }
        public ActionResult GetStudents() 
        {
            var s1 = new Student
            {
                Id=1,
                Name = "Raj",
                Cgpa = 8
            };
            var s2 = new Student
            {
                Id = 2,
                Name = "Dilip",
                Cgpa = 7
            };
            var s3 = new Student
            {
                Id = 3,
                Name = "Guru",
                Cgpa = 8.5f
            };
            var students = new List<Student> { s1, s2, s3 };
            return View(students);
        }
        public ActionResult GetStudentCollage()
        {
            var s1 = new Student
            {
                Id = 1,
                Name = "Raj",
                Cgpa = 8
            };
            var s2 = new Student
            {
                Id = 2,
                Name = "Dilip",
                Cgpa = 7
            };
            var s3 = new Student
            {
                Id = 3,
                Name = "Guru",
                Cgpa = 8.5f
            };
            var students = new List<Student> { s1, s2, s3 };
            var c1 = new Collage
            {
                Id = 1,
                Name = "SGGS"
            };
            var c2 = new Collage { 
                Id = 2,
                Name = "MGM"
            };
            var collages = new List<Collage> { c1, c2 };

            var vm = new GetStudentCollageVM
            {
                Students = students,
                Collages = collages
            };
            return View(vm);
        }
    }
}