using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingSystem.Infrastructure.Repository.Migrations
{
    public partial class CambioNOmbreParametro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro");

            migrationBuilder.RenameTable(
                name: "Parametro",
                newName: "Parametros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros",
                column: "IdParametro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros");

            migrationBuilder.RenameTable(
                name: "Parametros",
                newName: "Parametro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametro",
                table: "Parametro",
                column: "IdParametro");
        }
    }
}
