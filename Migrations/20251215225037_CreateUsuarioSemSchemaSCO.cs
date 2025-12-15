using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemCursosOnlineMapFluent.Migrations
{
    /// <inheritdoc />
    public partial class CreateUsuarioSemSchemaSCO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_USUARIO_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_USUARIO_UsuariosId",
                table: "CursoUsuario");

            migrationBuilder.RenameTable(
                name: "USUARIO",
                schema: "SCO",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_USUARIO_Email",
                table: "Usuarios",
                newName: "IX_Usuarios_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Usuarios_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes",
                column: "FK_Avaliacao_UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_Usuarios_UsuariosId",
                table: "CursoUsuario",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Usuarios_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_Usuarios_UsuariosId",
                table: "CursoUsuario");

            migrationBuilder.EnsureSchema(
                name: "SCO");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "USUARIO",
                newSchema: "SCO");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Email",
                schema: "SCO",
                table: "USUARIO",
                newName: "IX_USUARIO_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_USUARIO_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes",
                column: "FK_Avaliacao_UsuarioId",
                principalSchema: "SCO",
                principalTable: "USUARIO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_USUARIO_UsuariosId",
                table: "CursoUsuario",
                column: "UsuariosId",
                principalSchema: "SCO",
                principalTable: "USUARIO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
