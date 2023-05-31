using EFcoreConsoleApp.EF;
using EFcoreConsoleApp.Model;

var monocept = new Organization { EmployeeCount = 400, Name="Monocept" };
var db = new OrganizationDbContext();
//db.organizations.Add(monocept);
//db.SaveChanges();
var company = db.organizations.Single(o => o.Id == new Guid("5F32019D-F911-4645-8C31-08DB603533D0"));
Console.WriteLine(company.Name);
Console.WriteLine("End");