using AccountDALLib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDALLib.EF
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext() : base("AccountDbContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
