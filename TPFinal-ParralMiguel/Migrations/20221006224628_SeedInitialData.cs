using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPFinalParralMiguel.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioNombre",
                table: "Usuarios",
                newName: "usuarioNombre");

            migrationBuilder.RenameColumn(
                name: "UsuarioMail",
                table: "Usuarios",
                newName: "usuarioMail");

            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "Usuarios",
                newName: "contrasenia");

            migrationBuilder.RenameColumn(
                name: "UsuarioRol",
                table: "Usuarios",
                newName: "rol");

            migrationBuilder.RenameColumn(
                name: "PlatoPrecio",
                table: "Platos",
                newName: "precioPlato");

            migrationBuilder.RenameColumn(
                name: "PlatoNombre",
                table: "Platos",
                newName: "nombrePlato");

            migrationBuilder.RenameColumn(
                name: "PrecioTotal",
                table: "Pedidos",
                newName: "precioTotal");

            migrationBuilder.RenameColumn(
                name: "PedidoPreparado",
                table: "Pedidos",
                newName: "pedidoPreparado");

            migrationBuilder.AlterColumn<string>(
                name: "usuarioNombre",
                table: "Usuarios",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "usuarioMail",
                table: "Usuarios",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "contrasenia",
                table: "Usuarios",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombrePlato",
                table: "Platos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Platos",
                columns: new[] { "PlatoId", "PedidoId", "nombrePlato", "precioPlato" },
                values: new object[,]
                {
                    { 1, null, "Milanesa con guarnición", 1500f },
                    { 2, null, "Plato de pastas", 1200f },
                    { 3, null, "Hamburguesa con guarnición", 1600f },
                    { 4, null, "Gaseosa linea Pepsi", 750f }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "contrasenia", "usuarioMail", "usuarioNombre", "rol" },
                values: new object[,]
                {
                    { 1, "123", "pepe@gmail.com", "Pepe", "Admin" },
                    { 2, "456", "luci@gmail.com", "Lucia", "SuperAdmin" },
                    { 3, "789", "jose@gmail.com", "Jose", "SuperAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "usuarioNombre",
                table: "Usuarios",
                newName: "UsuarioNombre");

            migrationBuilder.RenameColumn(
                name: "usuarioMail",
                table: "Usuarios",
                newName: "UsuarioMail");

            migrationBuilder.RenameColumn(
                name: "contrasenia",
                table: "Usuarios",
                newName: "Contrasenia");

            migrationBuilder.RenameColumn(
                name: "rol",
                table: "Usuarios",
                newName: "UsuarioRol");

            migrationBuilder.RenameColumn(
                name: "precioPlato",
                table: "Platos",
                newName: "PlatoPrecio");

            migrationBuilder.RenameColumn(
                name: "nombrePlato",
                table: "Platos",
                newName: "PlatoNombre");

            migrationBuilder.RenameColumn(
                name: "precioTotal",
                table: "Pedidos",
                newName: "PrecioTotal");

            migrationBuilder.RenameColumn(
                name: "pedidoPreparado",
                table: "Pedidos",
                newName: "PedidoPreparado");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioNombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioMail",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Contrasenia",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PlatoNombre",
                table: "Platos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);
        }
    }
}
