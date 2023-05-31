using EFcoreCLI.Model;
using EFcoreCLI.EF;

public class Program
{
    public static void Main()
    {
        var monocept = new Organization { EmployeeCount = 400, Name = "Monocept" };
        var db = new OrganizationDbContext();
        db.organizations.Add(monocept);
        db.SaveChanges();
    }
}