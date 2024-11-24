using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanGiay.Migrations
{
    public partial class hung1232212344 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KICH_THUOCs",
                columns: table => new
                {
                    ID_KICH_THUOC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_KICH_THUOC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KICH_THUOCs", x => x.ID_KICH_THUOC);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_SAN_PHAMs",
                columns: table => new
                {
                    ID_LOAI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_LOAI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAI_SAN_PHAMs", x => x.ID_LOAI);
                });

            migrationBuilder.CreateTable(
                name: "MauSanPhamModel",
                columns: table => new
                {
                    ID_MAU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_MAU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSanPhamModel", x => x.ID_MAU);
                });

            migrationBuilder.CreateTable(
                name: "NGUOI_DUNGs",
                columns: table => new
                {
                    ID_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HO_TEN = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GTTT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAI_KHOAN = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MAT_KHAU = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    VAI_TRO = table.Column<int>(type: "int", nullable: false),
                    HINH_ANH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAY_TAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRANG_THAI = table.Column<int>(type: "int", nullable: false),
                    DIA_CHI = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGUOI_DUNGs", x => x.ID_NGUOI_DUNG);
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAMs",
                columns: table => new
                {
                    ID_SAN_PHAM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_SAN_PHAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_LOAI = table.Column<int>(type: "int", nullable: false),
                    ID_KICH_THUOC = table.Column<int>(type: "int", nullable: false),
                    SO_LUONG = table.Column<int>(type: "int", nullable: false),
                    GIA_NHAP = table.Column<int>(type: "int", nullable: false),
                    GIA_BAN = table.Column<int>(type: "int", nullable: false),
                    CHAT_LIEU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MO_TA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAY_TAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAN_PHAMs", x => x.ID_SAN_PHAM);
                    table.ForeignKey(
                        name: "FK_SAN_PHAMs_KICH_THUOCs_ID_KICH_THUOC",
                        column: x => x.ID_KICH_THUOC,
                        principalTable: "KICH_THUOCs",
                        principalColumn: "ID_KICH_THUOC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SAN_PHAMs_LOAI_SAN_PHAMs_ID_LOAI",
                        column: x => x.ID_LOAI,
                        principalTable: "LOAI_SAN_PHAMs",
                        principalColumn: "ID_LOAI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DON_HANGs",
                columns: table => new
                {
                    ID_DON_HANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    ID_NHAN_VIEN = table.Column<int>(type: "int", nullable: true),
                    NGAY_DAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRANG_THAI_DH = table.Column<int>(type: "int", nullable: false),
                    TRANG_THAI_THANH_TOAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAY_GIAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LY_DO_HUY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TEN_NGUOI_NHAN = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DON_HANGs", x => x.ID_DON_HANG);
                    table.ForeignKey(
                        name: "FK_DON_HANGs_NGUOI_DUNGs_ID_NGUOI_DUNG",
                        column: x => x.ID_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNGs",
                        principalColumn: "ID_NGUOI_DUNG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DON_HANGs_NGUOI_DUNGs_ID_NHAN_VIEN",
                        column: x => x.ID_NHAN_VIEN,
                        principalTable: "NGUOI_DUNGs",
                        principalColumn: "ID_NGUOI_DUNG");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID_COMMENT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDungComment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ID_SAN_PHAM = table.Column<int>(type: "int", nullable: false),
                    ID_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaoDanhGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID_COMMENT);
                    table.ForeignKey(
                        name: "FK_Comments_NGUOI_DUNGs_ID_NGUOI_DUNG",
                        column: x => x.ID_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNGs",
                        principalColumn: "ID_NGUOI_DUNG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_SAN_PHAMs_ID_SAN_PHAM",
                        column: x => x.ID_SAN_PHAM,
                        principalTable: "SAN_PHAMs",
                        principalColumn: "ID_SAN_PHAM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GIO_HANGs",
                columns: table => new
                {
                    ID_GIO_HANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NGUOI_DUNG = table.Column<int>(type: "int", nullable: false),
                    ID_SAN_PHAM = table.Column<int>(type: "int", nullable: false),
                    SO_LUONG_GH = table.Column<int>(type: "int", nullable: false),
                    THANH_TIEN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GIA_BAN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MAU_SP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANG_THAI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIO_HANGs", x => x.ID_GIO_HANG);
                    table.ForeignKey(
                        name: "FK_GIO_HANGs_NGUOI_DUNGs_ID_NGUOI_DUNG",
                        column: x => x.ID_NGUOI_DUNG,
                        principalTable: "NGUOI_DUNGs",
                        principalColumn: "ID_NGUOI_DUNG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GIO_HANGs_SAN_PHAMs_ID_SAN_PHAM",
                        column: x => x.ID_SAN_PHAM,
                        principalTable: "SAN_PHAMs",
                        principalColumn: "ID_SAN_PHAM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HINH_ANHs",
                columns: table => new
                {
                    ID_HINH_ANH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_HINH_ANH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_SAN_PHAM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HINH_ANHs", x => x.ID_HINH_ANH);
                    table.ForeignKey(
                        name: "FK_HINH_ANHs_SAN_PHAMs_ID_SAN_PHAM",
                        column: x => x.ID_SAN_PHAM,
                        principalTable: "SAN_PHAMs",
                        principalColumn: "ID_SAN_PHAM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM_MAUs",
                columns: table => new
                {
                    ID_MauSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_SAN_PHAM = table.Column<int>(type: "int", nullable: false),
                    ID_MAU = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAN_PHAM_MAUs", x => x.ID_MauSanPham);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_MAUs_MauSanPhamModel_ID_MAU",
                        column: x => x.ID_MAU,
                        principalTable: "MauSanPhamModel",
                        principalColumn: "ID_MAU",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_MAUs_SAN_PHAMs_ID_SAN_PHAM",
                        column: x => x.ID_SAN_PHAM,
                        principalTable: "SAN_PHAMs",
                        principalColumn: "ID_SAN_PHAM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_DON_HANGs",
                columns: table => new
                {
                    ID_CHI_TIET_DON_HANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DON_HANG = table.Column<int>(type: "int", nullable: false),
                    ID_SAN_PHAM = table.Column<int>(type: "int", nullable: false),
                    MauSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SO_LUONG = table.Column<int>(type: "int", nullable: false),
                    GIA_BAN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    THANH_TIEN = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHI_TIET_DON_HANGs", x => x.ID_CHI_TIET_DON_HANG);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_DON_HANGs_DON_HANGs_ID_DON_HANG",
                        column: x => x.ID_DON_HANG,
                        principalTable: "DON_HANGs",
                        principalColumn: "ID_DON_HANG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHI_TIET_DON_HANGs_SAN_PHAMs_ID_SAN_PHAM",
                        column: x => x.ID_SAN_PHAM,
                        principalTable: "SAN_PHAMs",
                        principalColumn: "ID_SAN_PHAM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "KICH_THUOCs",
                columns: new[] { "ID_KICH_THUOC", "TEN_KICH_THUOC" },
                values: new object[,]
                {
                    { 1, 40 },
                    { 2, 41 },
                    { 3, 42 },
                    { 4, 43 },
                    { 5, 44 }
                });

            migrationBuilder.InsertData(
                table: "LOAI_SAN_PHAMs",
                columns: new[] { "ID_LOAI", "TEN_LOAI" },
                values: new object[,]
                {
                    { 1, "Giày thể thao" },
                    { 2, "Giày chạy bộ" },
                    { 3, "Giày bóng rổ" },
                    { 4, "Giày lifestyle" }
                });

            migrationBuilder.InsertData(
                table: "MauSanPhamModel",
                columns: new[] { "ID_MAU", "TEN_MAU" },
                values: new object[,]
                {
                    { 1, "Đỏ" },
                    { 2, "Xanh dương" },
                    { 3, "Đen" },
                    { 4, "Trắng" },
                    { 5, "Xám" }
                });

            migrationBuilder.InsertData(
                table: "NGUOI_DUNGs",
                columns: new[] { "ID_NGUOI_DUNG", "AccessToken", "DIA_CHI", "EMAIL", "GTTT", "GoogleId", "HINH_ANH", "HO_TEN", "MAT_KHAU", "NGAY_TAO", "SDT", "TAI_KHOAN", "TRANG_THAI", "VAI_TRO" },
                values: new object[,]
                {
                    { 1, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user1@gmail.com", "CMND001", null, "avt1.jpg", "Trần Văn Lực", "password1", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2908), "0123456780", "user1", 0, 0 },
                    { 2, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user2@gmail.com", "CMND002", null, "avt1.jpg", "Trần Thị Yến ngọc", "password2", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2911), "0123456781", "user2", 0, 0 },
                    { 3, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user3@gmail.com", "CMND003", null, "avt1.jpg", "Nguyễn Ngọc Thạch", "password3", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2912), "0123456782", "user3", 0, 0 },
                    { 4, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user4@gmail.com", "CMND004", null, "avt1.jpg", "Nguyễn Tiến Thành", "password4", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2914), "0123456783", "user4", 0, 0 },
                    { 5, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user5@gmail.com", "CMND005", null, "avt1.jpg", "Nguyễn Thị Thu", "password5", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2915), "0123456784", "user5", 0, 0 },
                    { 6, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user6@gmail.com", "CMND006", null, "avt1.jpg", "Lê Hoàng Trọng Khôi", "password6", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2917), "0123456785", "user6", 0, 0 },
                    { 7, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user7@gmail.com", "CMND007", null, "avt1.jpg", "Võ Văn Đạt", "password7", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2919), "0123456786", "user7", 0, 0 },
                    { 8, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user8@gmail.com", "CMND008", null, "avt1.jpg", "Trần Thị Bích Nga", "password8", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2921), "0123456787", "user8", 0, 0 },
                    { 9, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user9@gmail.com", "CMND009", null, "avt1.jpg", "Nguyễn Trường Nhu", "password9", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2923), "0123456788", "user9", 0, 0 },
                    { 10, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "user10@gmail.com", "CMND010", null, "avt1.jpg", "Phạm Nguyên Phước", "password10", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2928), "0123456789", "user10", 0, 0 },
                    { 11, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "admin1@gmail.com", "CMND011", null, "Admin_images.jpg", "Võ Văn Hưng", "admin1", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2929), "0987654321", "admin1", 0, 1 },
                    { 12, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "admin2@gmail.com", "CMND012", null, "Admin_images.jpg", "Phạm Bá Hưng", "admin2", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2932), "0987654322", "admin2", 0, 1 },
                    { 13, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "employee1@gmail.com", "CMND013", null, "Employee_images.jpg", "Trần Tiến Quân", "NhanVien1", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2934), "0977554321", "NhanVien1", 0, 2 },
                    { 14, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "employee2@gmail.com", "CMND014", null, "Employee_images.jpg", "Ngô Kiến Huy", "employeepass2", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2935), "0977644322", "employee2", 0, 2 },
                    { 15, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "employee3@gmail.com", "CMND015", null, "Employee_images.jpg", "Nguyễn Trọng Tính", "employeepass3", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2939), "0977654323", "employee3", 1, 2 },
                    { 16, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "employee4@gmail.com", "CMND016", null, "Employee_images.jpg", "Trần Anh Đức", "employeepass4", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2942), "0977654324", "employee4", 0, 2 },
                    { 17, null, "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột", "employee5@gmail.com", "CMND017", null, "Employee_images.jpg", "Trần Văn Đức Hồng", "employeepass5", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2945), "0977654325", "employee5", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "SAN_PHAMs",
                columns: new[] { "ID_SAN_PHAM", "CHAT_LIEU", "GIA_BAN", "GIA_NHAP", "ID_KICH_THUOC", "ID_LOAI", "MO_TA", "NGAY_TAO", "SO_LUONG", "TEN_SAN_PHAM" },
                values: new object[,]
                {
                    { 1, "Vải dệt, Cao su", 2500000, 1500000, 3, 1, "Giày thể thao Nike Air Zoom Pegasus 40 với công nghệ Zoom Air giúp bạn chạy nhẹ nhàng và thoải mái.", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3153), 50, "Giày Nike Air Zoom Pegasus 40" },
                    { 2, "Vải dệt, Cao su, Phylon", 3000000, 1800000, 4, 2, "Giày chạy bộ Nike Zoom Fly 4 với đế giày Zoom giúp tạo độ đàn hồi tuyệt vời.", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3155), 30, "Giày Nike Zoom Fly 4" },
                    { 3, "Da, Cao su", 4500000, 2500000, 5, 3, "Giày bóng rổ Nike Air Jordan 1 Retro với thiết kế cổ điển, chất liệu da cao cấp, tạo cảm giác thoải mái khi chơi thể thao.", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3156), 20, "Giày Nike Air Jordan 1 Retro" },
                    { 4, "Vải dệt, Cao su, Phylon", 2900000, 1700000, 2, 1, "Giày thể thao Nike Air Max 270 với đế Air Max lớn tạo độ nảy và sự êm ái khi di chuyển.", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3158), 40, "Giày Nike Air Max 270" },
                    { 5, "Da, Cao su", 3500000, 2000000, 3, 4, "Giày Nike Air Force 1 '07 mang phong cách cổ điển, dễ dàng kết hợp với nhiều trang phục.", new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3159), 25, "Giày Nike Air Force 1 '07" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_DON_HANGs_ID_DON_HANG",
                table: "CHI_TIET_DON_HANGs",
                column: "ID_DON_HANG");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_DON_HANGs_ID_SAN_PHAM",
                table: "CHI_TIET_DON_HANGs",
                column: "ID_SAN_PHAM");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ID_NGUOI_DUNG",
                table: "Comments",
                column: "ID_NGUOI_DUNG");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ID_SAN_PHAM",
                table: "Comments",
                column: "ID_SAN_PHAM");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANGs_ID_NGUOI_DUNG",
                table: "DON_HANGs",
                column: "ID_NGUOI_DUNG");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANGs_ID_NHAN_VIEN",
                table: "DON_HANGs",
                column: "ID_NHAN_VIEN");

            migrationBuilder.CreateIndex(
                name: "IX_GIO_HANGs_ID_NGUOI_DUNG",
                table: "GIO_HANGs",
                column: "ID_NGUOI_DUNG");

            migrationBuilder.CreateIndex(
                name: "IX_GIO_HANGs_ID_SAN_PHAM",
                table: "GIO_HANGs",
                column: "ID_SAN_PHAM");

            migrationBuilder.CreateIndex(
                name: "IX_HINH_ANHs_ID_SAN_PHAM",
                table: "HINH_ANHs",
                column: "ID_SAN_PHAM");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MAUs_ID_MAU",
                table: "SAN_PHAM_MAUs",
                column: "ID_MAU");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MAUs_ID_SAN_PHAM",
                table: "SAN_PHAM_MAUs",
                column: "ID_SAN_PHAM");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAMs_ID_KICH_THUOC",
                table: "SAN_PHAMs",
                column: "ID_KICH_THUOC");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAMs_ID_LOAI",
                table: "SAN_PHAMs",
                column: "ID_LOAI");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHI_TIET_DON_HANGs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GIO_HANGs");

            migrationBuilder.DropTable(
                name: "HINH_ANHs");

            migrationBuilder.DropTable(
                name: "SAN_PHAM_MAUs");

            migrationBuilder.DropTable(
                name: "DON_HANGs");

            migrationBuilder.DropTable(
                name: "MauSanPhamModel");

            migrationBuilder.DropTable(
                name: "SAN_PHAMs");

            migrationBuilder.DropTable(
                name: "NGUOI_DUNGs");

            migrationBuilder.DropTable(
                name: "KICH_THUOCs");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAMs");
        }
    }
}
