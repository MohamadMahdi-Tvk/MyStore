using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Application.Interfaces.FacadPattern;
using MyStore.Application.Services.Carts;
using MyStore.Application.Services.Common.Queries.GetCategory;
using MyStore.Application.Services.Common.Queries.GetHomePageImages;
using MyStore.Application.Services.Common.Queries.GetMenuItem;
using MyStore.Application.Services.Common.Queries.GetSlider;
using MyStore.Application.Services.Fainances.Commands.AddRequestPay;
using MyStore.Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using MyStore.Application.Services.Fainances.Queries.GetRequestPayService;
using MyStore.Application.Services.HomePages.AddHomePageImages;
using MyStore.Application.Services.HomePages.AddNewSlider;
using MyStore.Application.Services.Orders.Commands.AddNewOrder;
using MyStore.Application.Services.Orders.Queries.GetOrdersForAdmin;
using MyStore.Application.Services.Orders.Queries.GetUserOrders;
using MyStore.Application.Services.Products.FacadPattern;
using MyStore.Application.Services.Users.FacadPattern;
using MyStore.Common.Roles;
using MyStore.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    options.AccessDeniedPath = new PathString("/Authentication/Signin");
});



builder.Services.AddControllersWithViews();

string connectionString = "Data Source=.; Initial Catalog = MyStoreDb; Integrated Security = true";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();

builder.Services.AddScoped<IUserFacad, UserFacad>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();

builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();

builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddRequestPayService, AddRequestPayService>();
builder.Services.AddScoped<IGetRequestPayService, GetRequestPayService>();
builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
builder.Services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
