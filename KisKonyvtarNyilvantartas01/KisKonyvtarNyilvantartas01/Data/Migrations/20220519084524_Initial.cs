using Microsoft.EntityFrameworkCore.Migrations;

namespace KisKonyvtarNyilvantartas01.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konyvek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cim = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Szerzo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Mufaj = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ar = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konyvek", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konyvek");
        }
    }
}
