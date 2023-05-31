namespace LinqAssignmentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = args;
            SortArgsNames(names);
            SortNamesByLength(names);
            NamesContaining_s(names);
            NamesNotContaining_a(names);
            string[] stringNumbers =
                { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            NumbersCaseStudy(stringNumbers);
        }

        private static void NumbersCaseStudy(string[] stringNumbers)
        {
            var numbers = stringNumbers.Select(s => int.Parse(s));
            Console.WriteLine("String to int converted numbers: " + string.Join(", ", numbers));
            var sum = numbers.Aggregate((x, y) => x + y);
            Console.WriteLine("Sum: " + sum);
            var evenSum = numbers.Where(n => n % 2 == 0).Aggregate((x, y) => x + y);
            Console.WriteLine("Sum of even numbers: " + evenSum);
            var oddSum = numbers.Where(n => n % 2 != 0).Aggregate((x, y) => x + y);
            Console.WriteLine("Sum of odd numbers: " + oddSum);
        }

        private static void NamesNotContaining_a(string[] names)
        {
            var namesNotContainingA = names.Where(n =>
                        !n.Contains("a", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Names Not Containing a :");
            foreach (string name in namesNotContainingA)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        private static void NamesContaining_s(string[] names)
        {
            var namesContainingS = names.Where(n =>
                        n.Contains("s", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Names Containing s:");
            foreach (string name in namesContainingS)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        private static void SortNamesByLength(string[] names)
        {
            var sortedNamesByLength = names.OrderByDescending(n => n.Length);
            Console.WriteLine("Sort Names By Length:");
            foreach (string name in sortedNamesByLength)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        private static void SortArgsNames(string[] names)
        {
            var sortedNames = names.OrderBy(n => n, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("SortArgsNames:");
            foreach (string name in sortedNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }
    }
}