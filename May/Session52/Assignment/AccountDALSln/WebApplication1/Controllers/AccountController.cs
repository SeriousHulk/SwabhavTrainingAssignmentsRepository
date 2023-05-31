using AccountDALLib.Model;
using AccountDALLib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepository _repository;
        public AccountController()
        {
            _repository = new AccountRepository();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account()
                {
                    Name = model.Name,
                    Password = HashPassword(model.Password), // Hash the password
                    Balance = model.InitialBalance
                };

                _repository.AddAccount(account);

                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = _repository.GetAccounts().FirstOrDefault(a => a.Name == model.Name);

                if (account != null && VerifyPassword(model.Password, account.Password))
                {
                    Session["AccountId"] = account.Id;
                    return RedirectToAction("Passbook");
                }
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Passbook()
        {
            int accountId = (int)Session["AccountId"];
            Account account = _repository.GetAccounts().FirstOrDefault(a => a.Id == accountId);

            if (account != null)
            {
                PassbookViewModel passbookViewModel = new PassbookViewModel()
                {
                    Account = account,
                    Transactions = account.Transactions
                };

                return View(passbookViewModel);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult DoTransaction()
        {
            int accountId = (int)Session["AccountId"];
            Account account = _repository.GetAccounts().FirstOrDefault(a => a.Id == accountId);

            if (account != null)
            {
                TransactionViewModel transactionViewModel = new TransactionViewModel()
                {
                    Account = account
                };

                return View(transactionViewModel);
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult DoTransaction(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                int accountId = (int)Session["AccountId"];
                Account account = _repository.GetAccounts().FirstOrDefault(a => a.Id == accountId);

                if (account != null)
                {
                    decimal amount = model.Amount;
                    string type = model.Type.ToUpper();

                    if (type == "D")
                    {
                        account.Balance += amount;
                    }
                    else if (type == "W")
                    {
                        if (account.Balance >= amount)
                        {
                            account.Balance -= amount;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Insufficient balance.");
                            return View(model);
                        }
                    }

                    Transaction transaction = new Transaction()
                    {
                        Name = account.Name,
                        Amount = amount,
                        AvailableBalance = account.Balance,
                        Type = type,
                        Date = DateTime.Now,
                        Account = account
                    };

                    account.Transactions.Add(transaction);

                    _repository.UpdateAccount(account);

                    return RedirectToAction("Passbook");
                }
            }

            ModelState.AddModelError("", "Invalid transaction details.");
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return storedPassword == hashedEnteredPassword;
        }
    }
}