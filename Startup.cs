using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices (IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddSession(options =>
        {
            // Session dies within 10 minutes of inactivity
            options.IdleTimeout = TimeSpan.FromMinutes(10);
        });
    }

    public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSession();
        
        /* Page not found default */
        app.UseExceptionHandler("/NotFound");
        //app.UseStatusCodePagesWithReExecute("/NotFound");
        app.UseHsts();

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        // Enable CORS
        app.UseCors(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .WithMethods("GET", "POST");
        });
        
        app.UseEndpoints(endpoints => 
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
            
            endpoints.MapControllerRoute(
                name: "notFound",
                pattern: "notFound",
                defaults: new { controller = "NotFound", action = "PageNotFound" }
            );

            endpoints.MapControllerRoute(
                name: "apiRoute",
                pattern: "api/{version}/{action}",
                defaults: new { controller = "Api", version = "v1", action = "time" }
            );
        });
    }
}