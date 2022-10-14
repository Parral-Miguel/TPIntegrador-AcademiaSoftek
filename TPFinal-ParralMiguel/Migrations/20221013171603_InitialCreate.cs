using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPFinalParralMiguel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    usuarioNombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    usuarioMail = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    contrasenia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PedidoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    pedidoPreparado = table.Column<bool>(type: "bit", nullable: false),
                    precioTotal = table.Column<float>(type: "real", nullable: false),
                    PedidoUsuarioUsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_PedidoUsuarioUsuarioId",
                        column: x => x.PedidoUsuarioUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Platos",
                columns: table => new
                {
                    PlatoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombrePlato = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    precioPlato = table.Column<float>(type: "real", nullable: false),
                    platoCantidad = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platos", x => x.PlatoId);
                    table.ForeignKey(
                        name: "FK_Platos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Platos_PedidoId",
                table: "Platos",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Platos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
