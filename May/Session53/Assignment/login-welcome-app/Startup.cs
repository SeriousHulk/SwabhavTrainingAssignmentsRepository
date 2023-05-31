public class Startup
{
    public IConfiguration Configuration { get; private set; }
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
            });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "Default", pattern: "{controller=Login}/{action=Index}/{id?}");
        });
    }
}