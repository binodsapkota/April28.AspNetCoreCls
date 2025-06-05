using FiltersInAspNet.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<JsonResultFilter>();
builder.Services.AddScoped<XmlResultFilter>();
// Add services to the container.
builder.Services.AddControllersWithViews(options => {
    //Register globally 
    options.Filters.Add<LogActionFilter>();
    options.Filters.Add<CustomExceptionFilter>();
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseExceptionHandler("/Home/Error");

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
