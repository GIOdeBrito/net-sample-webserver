using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices (IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
    {
        /* Page not found default */
        app.UseExceptionHandler("/NotFound");
        app.UseStatusCodePagesWithReExecute("/NotFound");
        app.UseHsts();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints => 
        {
            endpoints.MapControllerRoute(
                name: "notFound",
                pattern: "notFound",
                defaults: new { controller = "NotFound", action = "PageNotFound" }
            );

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            endpoints.MapControllerRoute(
                name: "getTime",
                pattern: "api/time",
                defaults: new { controller = "Time", action = "GetTime" }
            );
        });
    }
}