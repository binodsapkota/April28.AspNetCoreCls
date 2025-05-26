using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp;
using MyFirstMvcApp.Model;
using MyFirstMvcApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        //registering dbcontext dependancy
        builder.Services.AddDbContext<StudentDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<StudentDbContext>()
            .AddDefaultTokenProviders();



        builder.Services.AddTransient<ICourseService, CourseService>();
        builder.Services.AddScoped<ITimeService, TimeService>();

        /*
         service life time
            1. Transient - A new instance is created each time it is requested.
            2. Scoped - A new instance is created once per request.

            3. Singleton - A single instance is created and shared throughout the application.
         */

       

        // Authentication
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/Account/AccessDenied";
        });

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}