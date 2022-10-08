using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPFinalParralMiguel.Migrations
{
    /// <inheritdoc />
    public partial class newModelPlato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "platoPedido",
                table: "Platos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 1,
                column: "platoPedido",
                value: false);

            migrationBuilder.UpdateData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 2,
                column: "platoPedido",
                value: false);

            migrationBuilder.UpdateData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 3,
                column: "platoPedido",
                value: false);

            migrationBuilder.UpdateData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 4,
                column: "platoPedido",
                value: false);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "contrasenia",
                value: "123123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2,
                column: "contrasenia",
                value: "456456");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 3,
                columns: new[] { "contrasenia", "rol" },
                values: new object[] { "789789", "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "platoPedido",
                table: "Platos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "contrasenia",
                value: "123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2,
                column: "contrasenia",
                value: "456");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 3,
                columns: new[] { "contrasenia", "rol" },
                values: new object[] { "789", "SuperAdmin" });
        }
    }
}
