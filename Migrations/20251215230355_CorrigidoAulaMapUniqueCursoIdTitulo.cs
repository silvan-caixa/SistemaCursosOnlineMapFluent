using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemCursosOnlineMapFluent.Migrations
{
    /// <inheritdoc />
    public partial class CorrigidoAulaMapUniqueCursoIdTitulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Aulas_CursoId",
                table: "Aulas");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_Titulo",
                table: "Aulas");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_CursoId_Titulo",
                table: "Aulas",
                columns: new[] { "CursoId", "Titulo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Aulas_CursoId_Titulo",
                table: "Aulas");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_CursoId",
                table: "Aulas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_Titulo",
                table: "Aulas",
                column: "Titulo",
                unique: true);
        }
    }
}
