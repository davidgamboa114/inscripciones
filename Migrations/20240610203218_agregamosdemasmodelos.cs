using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inscripciones.Migrations
{
    /// <inheritdoc />
    public partial class agregamosdemasmodelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_AnioCarreras_AnioCarrerasId",
                table: "Materia");

            migrationBuilder.DropTable(
                name: "AnioCarreras");

            migrationBuilder.DropIndex(
                name: "IX_Materia_AnioCarrerasId",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "AnioCarrerasId",
                table: "Materia");

            migrationBuilder.CreateTable(
                name: "AnioCarrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnioCarrera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnioCarrera_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_AnioCarreraId",
                table: "Materia",
                column: "AnioCarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_AnioCarrera_CarreraId",
                table: "AnioCarrera",
                column: "CarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_AnioCarrera_AnioCarreraId",
                table: "Materia",
                column: "AnioCarreraId",
                principalTable: "AnioCarrera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_AnioCarrera_AnioCarreraId",
                table: "Materia");

            migrationBuilder.DropTable(
                name: "AnioCarrera");

            migrationBuilder.DropIndex(
                name: "IX_Materia_AnioCarreraId",
                table: "Materia");

            migrationBuilder.AddColumn<int>(
                name: "AnioCarrerasId",
                table: "Materia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnioCarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnioCarreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnioCarreras_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_AnioCarrerasId",
                table: "Materia",
                column: "AnioCarrerasId");

            migrationBuilder.CreateIndex(
                name: "IX_AnioCarreras_CarreraId",
                table: "AnioCarreras",
                column: "CarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_AnioCarreras_AnioCarrerasId",
                table: "Materia",
                column: "AnioCarrerasId",
                principalTable: "AnioCarreras",
                principalColumn: "Id");
        }
    }
}
