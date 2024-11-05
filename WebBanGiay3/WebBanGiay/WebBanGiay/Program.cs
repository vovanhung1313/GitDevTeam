using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Services;
using WebBanGiay.Repository;
using WebBanGiay.Repositoty;

var builder = WebApplication.CreateBuilder(args);

// C?u hình DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebBanGiay"));
});

// ??ng ký các d?ch v? c?n thi?t
builder.Services.AddScoped<EmailService>();
builder.Services.AddSingleton<IVnPayService, VnPayService>();

// C?u hình Cache và Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Thêm HttpContextAccessor ?? truy c?p HttpContext
builder.Services.AddHttpContextAccessor();

// Thêm MVC
builder.Services.AddControllersWithViews();

// C?u hình xác th?c b?ng Cookie và Google
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
    options.CallbackPath = "/signin-google"; // ??m b?o CallbackPath này kh?p v?i URI ?y quy?n c?a b?n
});

var app = builder.Build();

// X? lý ngo?i l? khi môi tr??ng không ph?i là Development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// C?u hình Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // ??m b?o g?i UseAuthentication tr??c UseAuthorization
app.UseAuthorization();
app.UseSession();

// ??ng ký Middleware ki?m tra quy?n
app.UseMiddleware<AuthorizationMiddleware>();

// ??nh ngh?a các route
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
