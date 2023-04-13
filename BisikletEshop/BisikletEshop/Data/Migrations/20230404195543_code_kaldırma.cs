using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletEshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class code_kaldırma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KuponKodu",
                table: "Siparisler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KuponKodu",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
