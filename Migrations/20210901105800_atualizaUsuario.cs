using Microsoft.EntityFrameworkCore.Migrations;

namespace CadstrarTarefasWebAPI.Migrations
{
    public partial class atualizaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Tarefas_TarefaId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Tarefas_TarefaId",
                table: "Usuarios",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Tarefas_TarefaId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "TarefaId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Tarefas_TarefaId",
                table: "Usuarios",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
