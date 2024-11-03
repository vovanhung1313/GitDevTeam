using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebBanGiay.Models; // Đảm bảo rằng bạn có namespace chứa NguoiDungModel

namespace WebBanGiay.Repository
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Lấy thông tin người dùng từ session
            var user = context.Session.GetJson<NguoiDungModel>("User");

            // Kiểm tra vai trò
            var isAdmin = user?.VAI_TRO == 1; // Vai trò Admin
            var isNhanVien = user?.VAI_TRO == 2; // Vai trò Nhân viên
            var isUser = user?.VAI_TRO == 0; // Vai trò Người dùng

            // Kiểm tra quyền truy cập vào trang Admin
            if (context.Request.Path.StartsWithSegments("/Admin") && !isAdmin)
            {
                context.Response.Redirect("/Home/Error"); // Redirect tới trang lỗi
                return;
            }

            // Kiểm tra quyền truy cập vào trang Nhân viên
            if (context.Request.Path.StartsWithSegments("/NhanVien") && !isNhanVien)
            {
                context.Response.Redirect("/Home/Error"); // Redirect tới trang lỗi
                return;
            }

            // Nếu không có vấn đề về quyền, tiếp tục xử lý
            await _next(context);
        }
    }
}
