using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class RemoveColumnFecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogos",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Catalogos");

            migrationBuilder.EnsureSchema(
                name: "Sistema");

            migrationBuilder.RenameTable(
                name: "Catalogos",
                newName: "Catalogo",
                newSchema: "Sistema");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "Sistema",
                table: "Catalogo",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                schema: "Sistema",
                table: "Catalogo",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogo",
                schema: "Sistema",
                table: "Catalogo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogo",
                schema: "Sistema",
                table: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Catalogo",
                schema: "Sistema",
                newName: "Catalogos");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Catalogos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Catalogos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "FechaAlta",
                table: "Catalogos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogos",
                table: "Catalogos",
                column: "Id");
        }
    }
}
