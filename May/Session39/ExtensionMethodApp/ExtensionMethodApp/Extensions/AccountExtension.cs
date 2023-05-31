using ExtensionMethodApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp.Extensions
{
    public static class AccountExtension
    {
        public static void PrintDetails(this Account account)
        {
            Console.WriteLine("Account No."+account.AccountNo);
            Console.WriteLine("Account Name."+account.Name);
            Console.WriteLine("Account Balance."+account.Balance);

        }
    }
}
