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
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (env.IsDevelopment())
        // {
        //     app.UseDeveloperExceptionPage();
        // }
        // else
        // {
        //     app.UseExceptionHandler("/Error");
        //     app.UseHsts();
        // }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        //app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Browse}/{id?}");
        });
    }
}