public class Program{
    public static void Main(string[] args){
        CreateHostBuilder(args)
            .Build() //configure services, DI services
            .Run();  //configure, request pipeline 
    }
    public static IHostBuilder CreateHostBuilder(string[] args){
        return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder=>{
                        webBuilder.UseStartup<Startup>();
                    });
    }
                    
}