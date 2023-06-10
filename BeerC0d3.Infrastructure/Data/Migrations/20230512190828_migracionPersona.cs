using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class migracionPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ChatGPT");

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "ChatGPT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    apellidoPaterno = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    apellidoMaterno = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona",
                schema: "ChatGPT");
        }
    }
}
