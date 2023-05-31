using MiddlewareMVCApp.Services;

namespace MiddlewareMVCApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddSingleton< IEmailServices,OutlookServices>();
            //builder.Services.AddTransient<IEmailServices,OutlookServices>();
            builder.Services.AddScoped<IEmailServices, OutlookServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware();
            app.Use(async (context, next) =>
            {
                Console.WriteLine("(RED)Before F1");
                await next(context);
                Console.WriteLine("(BLUE)After F1");
            });
            app.Use(async (context, next) =>
            {
                Console.WriteLine("(RED)Before F2");
                await next(context);
                Console.WriteLine("(BLUE)After F2");
            });
            app.Map("/api/hello", async (appBuilder) => {
                appBuilder.Use(async (context, next) =>
                {
                    Console.WriteLine("(RED)Before F3");
                    await next(context);
                    Console.WriteLine("(BLUE)After F3");
                });
                //app.Run(async (context) =>
                //{
                //    Console.WriteLine("(RED)Before F3");
                //    await context.Response.WriteAsync("End Of Pipiline");
                //});
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}