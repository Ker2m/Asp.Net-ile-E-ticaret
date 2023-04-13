using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletEshop.Data.Migrations
{
	/// <inheritdoc />
	public partial class sepet : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "SepetElemanlari",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UrunId = table.Column<int>(type: "int", nullable: false),
					SatisFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Adet = table.Column<int>(type: "int", nullable: false),
					SepetAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
					EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SepetElemanlari", x => x.Id);
					table.ForeignKey(
						name: "FK_SepetElemanlari_Urunler_UrunId",
						column: x => x.UrunId,
						principalTable: "Urunler",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Siparisler",
				columns: table => new
				{
					SiparisId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
					AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
					TeslimatAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
					TelefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
					EPostaAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
					KuponKodu = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Siparisler", x => x.SiparisId);
				});

			migrationBuilder.CreateTable(
				name: "SiparisDetaylari",
				columns: table => new
				{
					SiparisDetayId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UrunId = table.Column<int>(type: "int", nullable: false),
					SatisFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					SiparisAdedi = table.Column<int>(type: "int", nullable: false),
					SiparisId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SiparisDetaylari", x => x.SiparisDetayId);
					table.ForeignKey(
						name: "FK_SiparisDetaylari_Siparisler_SiparisId",
						column: x => x.SiparisId,
						principalTable: "Siparisler",
						principalColumn: "SiparisId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SiparisDetaylari_Urunler_UrunId",
						column: x => x.UrunId,
						principalTable: "Urunler",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_SepetElemanlari_UrunId",
				table: "SepetElemanlari",
				column: "UrunId");

			migrationBuilder.CreateIndex(
				name: "IX_SiparisDetaylari_SiparisId",
				table: "SiparisDetaylari",
				column: "SiparisId");

			migrationBuilder.CreateIndex(
				name: "IX_SiparisDetaylari_UrunId",
				table: "SiparisDetaylari",
				column: "UrunId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "SepetElemanlari");

			migrationBuilder.DropTable(
				name: "SiparisDetaylari");

			migrationBuilder.DropTable(
				name: "Siparisler");
		}
	}
}
