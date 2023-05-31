using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp.Model
{
    public class Account
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public Account(int accountNo, string name,int balance) 
        {
            this.AccountNo = accountNo;
            this.Name = name;
            this.Balance = balance;
        }
    }
}
