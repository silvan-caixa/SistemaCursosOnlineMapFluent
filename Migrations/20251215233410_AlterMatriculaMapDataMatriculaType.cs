using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemCursosOnlineMapFluent.Migrations
{
    /// <inheritdoc />
    public partial class AlterMatriculaMapDataMatriculaType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMatricula",
                table: "Matriculas",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMatricula",
                table: "Matriculas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
