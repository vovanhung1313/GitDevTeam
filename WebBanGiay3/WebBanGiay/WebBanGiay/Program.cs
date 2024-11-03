using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebBanGiay.Services;
using WebBanGiay.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebBanGiay.Repositoty;

var builder = WebApplication.CreateBuilder(args);

// C?u h�nh DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebBanGiay"));
});

// Th�m c�c d?ch v? c?n thi?t
builder.Services.AddScoped<EmailService>();
builder.Services.AddSingleton<IVnPayService, VnPayService>();

// C?u h�nh Cache v� Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Th�m HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Th�m MVC
builder.Services.AddControllersWithViews();

// C?u h�nh x�c th?c
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/NguoiDung/DangNhap"; // Chuy?n h??ng ??n trang ??ng nh?p
        options.LogoutPath = "/NguoiDung/DangKy"; // Chuy?n h??ng ??n trang ??ng xu?t
        options.AccessDeniedPath = "/NguoiDung/Home"; // Chuy?n h??ng khi kh�ng c� quy?n
    });


var app = builder.Build();

// C?u h�nh Exception Handling cho m�i tr??ng kh�ng ph?i l� Development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// C?u h�nh Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // ??m b?o g?i UseAuthentication tr??c UseAuthorization
app.UseAuthorization();
app.UseSession();

// Th�m middleware ki?m tra quy?n
app.UseMiddleware<AuthorizationMiddleware>(); // ??ng k� middleware ? ?�y

// ??nh ngh?a c�c route
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
