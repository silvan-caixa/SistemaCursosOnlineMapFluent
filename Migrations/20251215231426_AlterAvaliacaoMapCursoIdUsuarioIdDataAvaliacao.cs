using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemCursosOnlineMapFluent.Migrations
{
    /// <inheritdoc />
    public partial class AlterAvaliacaoMapCursoIdUsuarioIdDataAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Cursos_FK_Avaliacao_CursoId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Usuarios_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_FK_Avaliacao_CursoId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FK_Avaliacao_CursoId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FK_Avaliacao_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAvaliacao",
                table: "Avaliacoes",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_CursoId",
                table: "Avaliacoes",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_CursoId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAvaliacao",
                table: "Avaliacoes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "FK_Avaliacao_CursoId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FK_Avaliacao_UsuarioId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FK_Avaliacao_CursoId",
                table: "Avaliacoes",
                column: "FK_Avaliacao_CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes",
                column: "FK_Avaliacao_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Cursos_FK_Avaliacao_CursoId",
                table: "Avaliacoes",
                column: "FK_Avaliacao_CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Usuarios_FK_Avaliacao_UsuarioId",
                table: "Avaliacoes",
                column: "FK_Avaliacao_UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
