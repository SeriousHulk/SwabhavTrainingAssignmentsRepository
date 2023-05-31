using AccountDALLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication1.ViewModels
{
    public class TransactionViewModel
    {
        public Account Account { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid amount.")]
        public decimal Amount { get; set; }

        [Required]
        [RegularExpression("[DdWw]", ErrorMessage = "Please enter a valid transaction type (D or W).")]
        [Display(Name = "Transaction Type (D: Deposit, W: Withdraw)")]
        public string Type { get; set; }
    }
}