public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
                        .Build() //Configure Services => DI
                        .Run(); //Configure => Request Pipeline
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}