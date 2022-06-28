using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Migrations
{
    public partial class otomasyon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Derslers",
                schema: "dbo",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DersAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derslers", x => x.DersID);
                });

            migrationBuilder.CreateTable(
                name: "Notlars",
                schema: "dbo",
                columns: table => new
                {
                    NotID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OgrenciID = table.Column<int>(type: "integer", nullable: false),
                    DersID = table.Column<int>(type: "integer", nullable: false),
                    Vize = table.Column<int>(type: "integer", nullable: false),
                    Final = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notlars", x => x.NotID);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencilers",
                schema: "dbo",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OgrenciNo = table.Column<string>(type: "text", nullable: false),
                    OgrenciAd = table.Column<string>(type: "text", nullable: false),
                    OgrenciSoyad = table.Column<string>(type: "text", nullable: false),
                    TCK = table.Column<string>(type: "text", nullable: false),
                    Cinsiyet = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencilers", x => x.OgrenciID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Derslers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Notlars",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ogrencilers",
                schema: "dbo");
        }
    }
}
