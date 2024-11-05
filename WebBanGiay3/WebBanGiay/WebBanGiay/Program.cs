using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Services;
using WebBanGiay.Repository;
using WebBanGiay.Repositoty;

var builder = WebApplication.CreateBuilder(args);

// C?u h�nh DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebBanGiay"));
});

// ??ng k� c�c d?ch v? c?n thi?t
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

// Th�m HttpContextAccessor ?? truy c?p HttpContext
builder.Services.AddHttpContextAccessor();

// Th�m MVC
builder.Services.AddControllersWithViews();

// C?u h�nh x�c th?c b?ng Cookie v� Google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/NguoiDung/DangNhap";      // ???ng d?n trang ??ng nh?p
    options.LogoutPath = "/NguoiDung/DangKy";       // ???ng d?n trang ??ng xu?t
    options.AccessDeniedPath = "/NguoiDung/Home";   // ???ng d?n khi truy c?p b? t? ch?i
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Google:ClientId"];
    options.ClientSecret = builder.Configuration["Google:ClientSecret"];
    options.CallbackPath = "/signin-google"; // ??m b?o CallbackPath n�y kh?p v?i URI ?y quy?n c?a b?n
});

var app = builder.Build();

// X? l� ngo?i l? khi m�i tr??ng kh�ng ph?i l� Development
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

// ??ng k� Middleware ki?m tra quy?n
app.UseMiddleware<AuthorizationMiddleware>();

// ??nh ngh?a c�c route
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
