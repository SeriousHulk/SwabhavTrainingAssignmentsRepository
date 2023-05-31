using Microsoft.AspNetCore.Mvc;

public class Startup
{
    public IConfiguration Configuration { get; set; }
    public Startup(IConfiguration config)
    {
        this.Configuration = config;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddSession(options =>
            {
                options.Cookie.Name = "LoginMVCCoreApp.Session";
                options.IdleTimeout = System.TimeSpan.FromMinutes(30);
            });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession(); // Add this line to enable session support

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
        });
    }
}