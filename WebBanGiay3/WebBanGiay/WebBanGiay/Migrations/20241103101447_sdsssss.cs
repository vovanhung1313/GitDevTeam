﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanGiay.Migrations
{
    public partial class sdsssss : Migration
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
                    TAI_KHOAN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MAT_KHAU = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VAI_TRO = table.Column<int>(type: "int", nullable: false),
                    HINH_ANH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAY_TAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRANG_THAI = table.Column<int>(type: "int", nullable: false),
                    DIA_CHI = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
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
                name: "MAU_SACs",
                columns: table => new
                {
                    ID_MAU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN_MAU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SanPhamModelID_SAN_PHAM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAU_SACs", x => x.ID_MAU);
                    table.ForeignKey(
                        name: "FK_MAU_SACs_SAN_PHAMs_SanPhamModelID_SAN_PHAM",
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
                        name: "FK_SAN_PHAM_MAUs_MAU_SACs_ID_MAU",
                        column: x => x.ID_MAU,
                        principalTable: "MAU_SACs",
                        principalColumn: "ID_MAU",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_MAUs_SAN_PHAMs_ID_SAN_PHAM",
                        column: x => x.ID_SAN_PHAM,
                        principalTable: "SAN_PHAMs",
                        principalColumn: "ID_SAN_PHAM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HINH_ANHs_ID_SAN_PHAM",
                table: "HINH_ANHs",
                column: "ID_SAN_PHAM");

            migrationBuilder.CreateIndex(
                name: "IX_MAU_SACs_SanPhamModelID_SAN_PHAM",
                table: "MAU_SACs",
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
                name: "MAU_SACs");

            migrationBuilder.DropTable(
                name: "SAN_PHAMs");

            migrationBuilder.DropTable(
                name: "KICH_THUOCs");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAMs");
        }
    }
}
