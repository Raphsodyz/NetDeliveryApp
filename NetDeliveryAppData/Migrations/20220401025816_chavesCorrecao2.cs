using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetDeliveryAppData.Migrations
{
    public partial class chavesCorrecao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bebidas_Pedidos_PedidoId",
                table: "Bebidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Hamburguers_Pedidos_PedidoId",
                table: "Hamburguers");

            migrationBuilder.DropIndex(
                name: "IX_Hamburguers_PedidoId",
                table: "Hamburguers");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Bebidas_PedidoId",
                table: "Bebidas");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Hamburguers");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Bebidas");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Clientes",
                newName: "PedidosId");

            migrationBuilder.AddColumn<int>(
                name: "BebidaId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HamburguerId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_BebidaId",
                table: "Pedidos",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_HamburguerId",
                table: "Pedidos",
                column: "HamburguerId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Bebidas_BebidaId",
                table: "Pedidos",
                column: "BebidaId",
                principalTable: "Bebidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Hamburguers_HamburguerId",
                table: "Pedidos",
                column: "HamburguerId",
                principalTable: "Hamburguers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Bebidas_BebidaId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Hamburguers_HamburguerId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_BebidaId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_HamburguerId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "BebidaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "HamburguerId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "PedidosId",
                table: "Clientes",
                newName: "EnderecoId");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Hamburguers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Bebidas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hamburguers_PedidoId",
                table: "Hamburguers",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bebidas_PedidoId",
                table: "Bebidas",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bebidas_Pedidos_PedidoId",
                table: "Bebidas",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamburguers_Pedidos_PedidoId",
                table: "Hamburguers",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }
    }
}
