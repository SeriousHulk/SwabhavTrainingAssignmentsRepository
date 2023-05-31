using System.ComponentModel.DataAnnotations;

namespace EmployeeMVCcoreCRUD.ViewModels
{
    public class EmployeeEditVM
    {
        //public string Title { get; set; }
        //public string ErrorMessage { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public double EmployeeSalary { get; set; }
    }
}
