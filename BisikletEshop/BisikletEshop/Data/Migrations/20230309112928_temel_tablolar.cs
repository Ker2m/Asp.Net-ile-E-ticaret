using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletEshop.Data.Migrations
{
	/// <inheritdoc />
	public partial class temeltablolar : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "İletisim",
				columns: table => new
				{
					İletisimId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					MesajMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
					OkunmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_İletisim", x => x.İletisimId);
				});

			migrationBuilder.CreateTable(
				name: "Kategoriler",
				columns: table => new
				{
					KategoriId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
					foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
				});

			migrationBuilder.CreateTable(
				name: "Marka",
				columns: table => new
				{
					MarkaId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Marka", x => x.MarkaId);
				});

			migrationBuilder.CreateTable(
				name: "Urunler",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
					KategoriId = table.Column<int>(type: "int", nullable: false),
					MarkaId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Urunler", x => x.Id);
					table.ForeignKey(
						name: "FK_Urunler_Kategoriler_KategoriId",
						column: x => x.KategoriId,
						principalTable: "Kategoriler",
						principalColumn: "KategoriId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Urunler_Marka_MarkaId",
						column: x => x.MarkaId,
						principalTable: "Marka",
						principalColumn: "MarkaId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Urunler_KategoriId",
				table: "Urunler",
				column: "KategoriId");

			migrationBuilder.CreateIndex(
				name: "IX_Urunler_MarkaId",
				table: "Urunler",
				column: "MarkaId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "İletisim");

			migrationBuilder.DropTable(
				name: "Urunler");

			migrationBuilder.DropTable(
				name: "Kategoriler");

			migrationBuilder.DropTable(
				name: "Marka");
		}
	}
}
