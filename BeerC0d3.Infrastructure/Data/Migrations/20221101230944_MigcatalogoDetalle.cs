using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class MigcatalogoDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogoDetalle",
                schema: "Sistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatId = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechAlta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogoDetalle_Catalogo_CatId",
                        column: x => x.CatId,
                        principalSchema: "Sistema",
                        principalTable: "Catalogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoDetalle_CatId",
                schema: "Sistema",
                table: "CatalogoDetalle",
                column: "CatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoDetalle",
                schema: "Sistema");
        }
    }
}
