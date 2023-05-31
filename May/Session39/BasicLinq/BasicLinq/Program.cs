using System.Linq;
// See https://aka.ms/new-console-template for more information
IEnumerable<string> names = args;
var query1 = names.Where(n => n.ToLower().Contains("a"));
var query2 = query1.Take(3).OrderByDescending(n => n);

Console.WriteLine(query1);
Console.WriteLine(query2);
query1.ToList().ForEach(Console.WriteLine);
Console.WriteLine();
query2.ToList().ForEach(n=>Console.WriteLine(n));
Console.WriteLine("End");