using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingSystem.Infrastructure.Repository.Migrations
{
    public partial class CorreccionEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPersona",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPersona",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
