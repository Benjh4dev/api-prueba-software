using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_prueba_software.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id_book = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id_book);
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    date_reserve = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    facultad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id_book", "description", "name" },
                values: new object[,]
                {
                    { 1, "Descripción del libro 1", "Libro 1" },
                    { 2, "Descripción del libro 2", "Libro 2" },
                    { 3, "Descripción del libro 3", "Libro 3" },
                    { 4, "Descripción del libro 4", "Libro 4" }
                });

            migrationBuilder.InsertData(
                table: "Reserves",
                columns: new[] { "id", "book_id", "code", "date_reserve", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(2023, 6, 9, 12, 47, 19, 454, DateTimeKind.Local).AddTicks(8228), 1 },
                    { 2, 2, 0, new DateTime(2023, 6, 2, 12, 47, 19, 454, DateTimeKind.Local).AddTicks(8256), 1 },
                    { 3, 3, 0, new DateTime(2023, 5, 26, 12, 47, 19, 454, DateTimeKind.Local).AddTicks(8259), 2 },
                    { 4, 4, 0, new DateTime(2023, 5, 19, 12, 47, 19, 454, DateTimeKind.Local).AddTicks(8261), 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "facultad", "name" },
                values: new object[,]
                {
                    { 1, "Facultad 1", "Usuario 1" },
                    { 2, "Facultad 2", "Usuario 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
