using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Class_Düzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Urunler",
                newName: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrunId",
                table: "Urunler",
                newName: "Id");
        }
    }
}
