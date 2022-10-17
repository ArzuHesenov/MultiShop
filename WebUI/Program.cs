using Buisness.Abstract;
using Buisness.Concrete;
using Core.Models.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<AppDbContext>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryManager>();
builder.Services.AddScoped<ISubCategoryDal, SubCategoryDal>();

builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase= false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase= false;
   // option.Password.RequiredLength = 6;
});

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
