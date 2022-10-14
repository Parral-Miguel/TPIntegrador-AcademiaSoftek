using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPFinalParralMiguel.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePedidoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_PedidoUsuarioUsuarioId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_PedidoUsuarioUsuarioId",
                table: "Pedidos");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "4ac051d9-4c5a-4bd0-8010-07a3a442b311");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "51194b63-408a-471f-9178-06f0d662d0b6");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "7a72055d-bef0-4de6-8de3-98a8896c5ed8");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "d91546a9-d443-46ee-9149-fe8499911a6d");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "c21f0e9d-1180-445b-9da8-cbbffcab6312");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "f12ed565-8ffc-48f8-a103-86cde5743555");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "fde20520-bde8-441e-8e8c-1c00766b5f92");

            migrationBuilder.DropColumn(
                name: "PedidoUsuarioUsuarioId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "PedidoUsuarioId",
                table: "Pedidos",
                newName: "pedidoUsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "pedidoUsuarioId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Platos",
                columns: new[] { "PlatoId", "PedidoId", "platoCantidad", "nombrePlato", "precioPlato" },
                values: new object[,]
                {
                    { "0b15307f-db48-4af5-ba76-9a43e762123a", null, 0, "Plato de pastas", 1200f },
                    { "474426ff-ab9f-4a95-bc18-1d5f58587ee6", null, 0, "Gaseosa linea Pepsi", 750f },
                    { "8bd50cf5-1bcb-4522-a3d6-d9dc9bd21bf1", null, 0, "Hamburguesa con guarnición", 1600f },
                    { "eac4a6b1-b9cf-4b63-ad4b-8580aa673f36", null, 0, "Milanesa con guarnición", 1500f }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "contrasenia", "usuarioMail", "usuarioNombre", "rol" },
                values: new object[,]
                {
                    { "37d0aea7-1bce-49e1-b04d-649aae6dc3dc", "789", "jose@gmail.com", "Jose", "User" },
                    { "a658f080-2ad8-4835-a669-1531910f505b", "456", "luci@gmail.com", "Lucia", "SuperAdmin" },
                    { "cd0c749c-ae91-46b1-8b48-5750f63a32b8", "123", "pepe@gmail.com", "Pepe", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_pedidoUsuarioId",
                table: "Pedidos",
                column: "pedidoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_pedidoUsuarioId",
                table: "Pedidos",
                column: "pedidoUsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_pedidoUsuarioId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_pedidoUsuarioId",
                table: "Pedidos");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "0b15307f-db48-4af5-ba76-9a43e762123a");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "474426ff-ab9f-4a95-bc18-1d5f58587ee6");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "8bd50cf5-1bcb-4522-a3d6-d9dc9bd21bf1");

            migrationBuilder.DeleteData(
                table: "Platos",
                keyColumn: "PlatoId",
                keyValue: "eac4a6b1-b9cf-4b63-ad4b-8580aa673f36");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "37d0aea7-1bce-49e1-b04d-649aae6dc3dc");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "a658f080-2ad8-4835-a669-1531910f505b");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "cd0c749c-ae91-46b1-8b48-5750f63a32b8");

            migrationBuilder.RenameColumn(
                name: "pedidoUsuarioId",
                table: "Pedidos",
                newName: "PedidoUsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoUsuarioId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PedidoUsuarioUsuarioId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Platos",
                columns: new[] { "PlatoId", "PedidoId", "platoCantidad", "nombrePlato", "precioPlato" },
                values: new object[,]
                {
                    { "4ac051d9-4c5a-4bd0-8010-07a3a442b311", null, 0, "Milanesa con guarnición", 1500f },
                    { "51194b63-408a-471f-9178-06f0d662d0b6", null, 0, "Gaseosa linea Pepsi", 750f },
                    { "7a72055d-bef0-4de6-8de3-98a8896c5ed8", null, 0, "Plato de pastas", 1200f },
                    { "d91546a9-d443-46ee-9149-fe8499911a6d", null, 0, "Hamburguesa con guarnición", 1600f }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "contrasenia", "usuarioMail", "usuarioNombre", "rol" },
                values: new object[,]
                {
                    { "c21f0e9d-1180-445b-9da8-cbbffcab6312", "456", "luci@gmail.com", "Lucia", "SuperAdmin" },
                    { "f12ed565-8ffc-48f8-a103-86cde5743555", "123", "pepe@gmail.com", "Pepe", "Admin" },
                    { "fde20520-bde8-441e-8e8c-1c00766b5f92", "789", "jose@gmail.com", "Jose", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedidoUsuarioUsuarioId",
                table: "Pedidos",
                column: "PedidoUsuarioUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_PedidoUsuarioUsuarioId",
                table: "Pedidos",
                column: "PedidoUsuarioUsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }
    }
}
