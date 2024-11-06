using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanGiay.Migrations
{
    public partial class themDuLieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KICH_THUOCs",
                columns: table => new
                {
                    ID_KICH_THUOC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_KICH_THUOC = table.Column<int>(type: "int", maxLength: 1, nullable: false)
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
                    DIA_CHI = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    ID_LOAI_SAN_PHAM = table.Column<int>(type: "int", nullable: true),
                    ID_KICH_THUOC = table.Column<int>(type: "int", nullable: false),
                    SO_LUONG = table.Column<int>(type: "int", nullable: false),
                    GIA_NHAP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GIA_BAN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                        name: "FK_SAN_PHAMs_LOAI_SAN_PHAMs_ID_LOAI_SAN_PHAM",
                        column: x => x.ID_LOAI_SAN_PHAM,
                        principalTable: "LOAI_SAN_PHAMs",
                        principalColumn: "ID_LOAI");
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
                name: "MauSanPhamModel",
                columns: table => new
                {
                    ID_MAU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_MAU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SanPhamModelID_SAN_PHAM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSanPhamModel", x => x.ID_MAU);
                    table.ForeignKey(
                        name: "FK_MauSanPhamModel_SAN_PHAMs_SanPhamModelID_SAN_PHAM",
                        column: x => x.SanPhamModelID_SAN_PHAM,
                        principalTable: "SAN_PHAMs",
                        principalColumn: "ID_SAN_PHAM");
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

            migrationBuilder.InsertData(
                table: "NGUOI_DUNGs",
                columns: new[] { "ID_NGUOI_DUNG", "AccessToken", "DIA_CHI", "EMAIL", "GTTT", "GoogleId", "HINH_ANH", "HO_TEN", "MAT_KHAU", "NGAY_TAO", "SDT", "TAI_KHOAN", "TRANG_THAI", "VAI_TRO" },
                values: new object[,]
                {
                    { 1, null, "Địa chỉ 1", "khachhang1@example.com", "CMND", null, "avt1.jpg", "Hồ Huy Linh", "matkhau1", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3931), "0912345671", "khachhang1", 0, 0 },
                    { 2, null, "Địa chỉ 2", "khachhang2@example.com", "CMND", null, "avt1.jpg", "Hồ Huy Long", "matkhau2", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3934), "0912345672", "khachhang2", 0, 0 },
                    { 3, null, "Địa chỉ 3", "khachhang3@example.com", "CMND", null, "avt1.jpg", "Hồ Huy Quân", "matkhau3", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3936), "0912345673", "khachhang3", 0, 0 },
                    { 4, null, "Địa chỉ 4", "khachhang4@example.com", "CMND", null, "avt1.jpg", "Võ Văn Hưng", "matkhau4", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3937), "0912345674", "khachhang4", 0, 0 },
                    { 5, null, "Địa chỉ 5", "khachhang5@example.com", "CMND", null, "avt1.jpg", "Phạm Bá Hậu", "matkhau5", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3938), "0912345675", "khachhang5", 0, 0 },
                    { 6, null, "Địa chỉ 6", "khachhang6@example.com", "CMND", null, "avt1.jpg", "Nguyễn Quang Quý", "matkhau6", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3940), "0912345676", "khachhang6", 0, 0 },
                    { 7, null, "Địa chỉ 7", "khachhang7@example.com", "CMND", null, "avt1.jpg", "Nguyễn Gia Nghi", "matkhau7", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3943), "0912345677", "khachhang7", 0, 0 },
                    { 8, null, "Địa chỉ 8", "khachhang8@example.com", "CMND", null, "avt1.jpg", "Nguyễn Phú Hưng", "matkhau8", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3946), "0912345678", "khachhang8", 0, 0 },
                    { 9, null, "Địa chỉ 9", "khachhang9@example.com", "CMND", null, "avt1.jpg", "Phạm Phượng", "matkhau9", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3947), "0912345679", "khachhang9", 0, 0 },
                    { 10, null, "Địa chỉ 10", "khachhang10@example.com", "CMND", null, "avt1.jpg", "Tạ Minh Tâm", "matkhau10", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3948), "0912345680", "khachhang10", 0, 0 },
                    { 11, null, "Địa chỉ Admin 1", "admin1@example.com", "CMND", null, "avt1.jpg", "Võ Văn Hưng", "matkhau11", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4008), "0912345681", "admin1", 0, 1 },
                    { 12, null, "Địa chỉ Admin 2", "admin2@example.com", "CMND", null, "avt1.jpg", "Bùi Phương Linh", "matkhau12", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4010), "0912345682", "admin2", 0, 1 },
                    { 13, null, "Địa chỉ Admin 3", "admin3@example.com", "CMND", null, "avt1.jpg", "Nguyễn Hoàng Trọng Khôi", "matkhau13", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4011), "0912345683", "admin3", 0, 1 },
                    { 14, null, "Địa chỉ Nhân Viên 1", "nhanvien1@example.com", "CMND", null, "avt1.jpg", "Nguyễn Hoàng Anh", "matkhau14", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4013), "0912345684", "nhanvien1", 0, 2 },
                    { 15, null, "Địa chỉ Nhân Viên 2", "nhanvien2@example.com", "CMND", null, "avt1.jpg", "Phạm Ngũ Lão", "matkhau15", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4014), "0912345685", "nhanvien2", 0, 2 },
                    { 16, null, "Địa chỉ Nhân Viên 3", "nhanvien3@example.com", "CMND", null, "avt1.jpg", "Trần Quốc Toản", "matkhau16", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4017), "0912345686", "nhanvien3", 0, 2 },
                    { 17, null, "Địa chỉ Nhân Viên 4", "nhanvien4@example.com", "CMND", null, "avt1.jpg", "Phạm Bá Thiên", "matkhau17", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4019), "0912345687", "nhanvien4", 0, 2 },
                    { 18, null, "Địa chỉ Nhân Viên 5", "nhanvien5@example.com", "CMND", null, "avt1.jpg", "Trần Tiến Luật", "matkhau18", new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4020), "0912345688", "nhanvien5", 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HINH_ANHs_ID_SAN_PHAM",
                table: "HINH_ANHs",
                column: "ID_SAN_PHAM");

            migrationBuilder.CreateIndex(
                name: "IX_MauSanPhamModel_SanPhamModelID_SAN_PHAM",
                table: "MauSanPhamModel",
                column: "SanPhamModelID_SAN_PHAM");

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
                name: "IX_SAN_PHAMs_ID_LOAI_SAN_PHAM",
                table: "SAN_PHAMs",
                column: "ID_LOAI_SAN_PHAM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HINH_ANHs");

            migrationBuilder.DropTable(
                name: "NGUOI_DUNGs");

            migrationBuilder.DropTable(
                name: "SAN_PHAM_MAUs");

            migrationBuilder.DropTable(
                name: "MauSanPhamModel");

            migrationBuilder.DropTable(
                name: "SAN_PHAMs");

            migrationBuilder.DropTable(
                name: "KICH_THUOCs");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAMs");
        }
    }
}
