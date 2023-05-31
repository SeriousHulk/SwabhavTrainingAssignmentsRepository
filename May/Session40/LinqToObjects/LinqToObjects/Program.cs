using LinqToObjects.Model;
using System.Linq;

List<Account> accounts = new List<Account>
{
    new Account{ AccountNo =1001, Balance=2000, Location="Raipur", Name= "Ekta"},
    new Account{ AccountNo =1002, Balance=2000, Location="Gaya", Name= "Ravi"},
    new Account{ AccountNo =1003, Balance=1000, Location="Satara", Name= "Shubh"},
    new Account{ AccountNo =1004, Balance=3000, Location="Nanded", Name= "Vikrant"},
    new Account{ AccountNo =1005, Balance=4000, Location="Hyderabad", Name= "Manjunath"},
    new Account{ AccountNo =1006, Balance=2000, Location="SambhajiNagar", Name= "Anekant"},
    new Account{ AccountNo =1007, Balance=2000, Location="Varanasi", Name= "Gautam"}
};

//CaseStudy1(accounts);
//CaseStudy2(accounts);
CaseStudy3(accounts);

void CaseStudy3(List<Account> accounts)
{
    var richestThree = accounts.OrderByDescending(a => a.Balance).Take(3).Select(account => new
    {
        FullName = account.Name,
        Balance = account.Balance,
    });

    richestThree.ToList().ForEach(a =>
    {
        Console.WriteLine(a.FullName);
        Console.WriteLine(a.Balance);
    });
}

void CaseStudy2(List<Account> accounts)
{
    var namesAndBalance = accounts.OrderBy(a=>a.Name).Select(account => new
    {
        FullName = account.Name,
        Balance = account.Balance,
    });

    namesAndBalance.ToList().ForEach(a =>
    {
        Console.WriteLine(a.FullName);
        Console.WriteLine(a.Balance);
    });
}

void CaseStudy1(List<Account> accounts)
{
    var namesFromAccounts = from account in accounts
                            where account.Balance>2000
                            orderby account.Name
                            select new
                            {
                                FullName = account.Name,
                                Balance = account.Balance,
                            };
    Console.WriteLine(namesFromAccounts);
    foreach (var name in namesFromAccounts)
    {
        Console.WriteLine(name.FullName);
        Console.WriteLine(name.Balance);
    } ;
}