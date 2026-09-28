using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biblioteca_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedLibrosYSocios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "libros",
                columns: new[] { "Id", "Autor", "Genero", "Isbn", "PrestamoId", "Stock", "Titulo" },
                values: new object[,]
                {
                    { 1, "James Clear", "Desarrollo personal", 9783442178582L, null, 2, "Habitos Atomicos" },
                    { 2, "Gabriel García Márquez", "Realismo mágico", 9780307474728L, null, 3, "Cien Años de Soledad" },
                    { 3, "George Orwell", "Ciencia ficción", 9780451524935L, null, 4, "1984" },
                    { 4, "Antoine de Saint-Exupéry", "Fábula", 9780156012195L, null, 5, "El Principito" },
                    { 5, "Yuval Noah Harari", "Divulgación histórica", 9780062316097L, null, 2, "Sapiens" }
                });

            migrationBuilder.InsertData(
                table: "socios",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "calle falsa 123", "Gaston", "1928376452" },
                    { 2, "pozo de vargas 2258", "Marcos", "+5491124048045" },
                    { 3, "avenida de los patos 43", "Valeria", "3544344343" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "libros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "libros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "libros",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "libros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "libros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "socios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "socios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "socios",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
