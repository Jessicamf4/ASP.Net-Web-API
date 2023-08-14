using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAlimentacao.Migrations
{
    public partial class VinculoRefeicaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Refeicao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_UsuarioId",
                table: "Refeicao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicao_Usuarios_UsuarioId",
                table: "Refeicao",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_Usuarios_UsuarioId",
                table: "Refeicao");

            migrationBuilder.DropIndex(
                name: "IX_Refeicao_UsuarioId",
                table: "Refeicao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Refeicao");
        }
    }
}
