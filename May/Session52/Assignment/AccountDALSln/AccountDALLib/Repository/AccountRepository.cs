using AccountDALLib.EF;
using AccountDALLib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDALLib.Repository
{
    public class AccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository()
        {
            _context = new AccountDbContext();
        }

        public void AddAccount(Account account)
        {
            account.Transactions = new List<Transaction>(); // Initialize the Transactions collection
            _context.Accounts.Add(account);

            // Create and add the initial transaction
            Transaction transaction = new Transaction()
            {
                Name = account.Name,
                AvailableBalance = account.Balance,
                Type = "D",
                Date = DateTime.Now,
                Account = account
            };
            _context.Transactions.Add(transaction);

            _context.SaveChanges();
        }

        public List<Account> GetAccounts()
        {
            return _context.Accounts.Include(a => a.Transactions).ToList();
        }
        public void UpdateAccount(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
