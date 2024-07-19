using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreMaquina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioHora = table.Column<double>(type: "float", nullable: false),
                    frecuenciaMantenimiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObrasPublicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreObra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasPublicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstimacionMaquinas",
                columns: table => new
                {
                    obraId = table.Column<int>(type: "int", nullable: false),
                    maquinaId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    horas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimacionMaquinas", x => new { x.obraId, x.maquinaId });
                    table.ForeignKey(
                        name: "FK_EstimacionMaquinas_Maquinas_maquinaId",
                        column: x => x.maquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimacionMaquinas_ObrasPublicas_obraId",
                        column: x => x.obraId,
                        principalTable: "ObrasPublicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstimacionMaquinas_maquinaId",
                table: "EstimacionMaquinas",
                column: "maquinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstimacionMaquinas");

            migrationBuilder.DropTable(
                name: "Maquinas");

            migrationBuilder.DropTable(
                name: "ObrasPublicas");
        }
    }
}
