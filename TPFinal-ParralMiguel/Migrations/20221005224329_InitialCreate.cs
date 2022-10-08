using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    PedidoPreparado = table.Column<bool>(type: "bit", nullable: false),
                    PrecioTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_PedidoUsuarioId",
                        column: x => x.PedidoUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platos",
                columns: table => new
                {
                    PlatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatoPrecio = table.Column<float>(type: "real", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedidoUsuarioId",
                table: "Pedidos",
                column: "PedidoUsuarioId");

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
