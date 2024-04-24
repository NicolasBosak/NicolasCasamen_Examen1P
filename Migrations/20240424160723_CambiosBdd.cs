using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicolasCasamen_Examen1P.Migrations
{
    public partial class CambiosBdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NC_Cine",
                columns: table => new
                {
                    NC_NumeroBoleto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NC_Pelicula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NC_FechaPelicula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NC_Entradas = table.Column<int>(type: "int", nullable: false),
                    NC_Socio = table.Column<bool>(type: "bit", nullable: false),
                    NC_Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NC_Cine", x => x.NC_NumeroBoleto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NC_Cine");
        }
    }
}
