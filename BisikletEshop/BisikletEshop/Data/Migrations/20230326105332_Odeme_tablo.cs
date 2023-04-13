using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Odeme_tablo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GüvenlikKodu",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KartNumarası",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KartUzerindekiAd",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SonKullanmaTarihi",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GüvenlikKodu",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "KartNumarası",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "KartUzerindekiAd",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "SonKullanmaTarihi",
                table: "Siparisler");
        }
    }
}
