using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetDeliveryAppData.Migrations
{
    public partial class tabelasCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Acrescimos",
                table: "Hamburguers");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Entregue",
                table: "Pedidos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Pagamento",
                table: "Pedidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Troco",
                table: "Pedidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Hamburguers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Clientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Bebidas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sabor",
                table: "Bebidas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Bebidas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Entregue",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Pagamento",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Troco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Hamburguers");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Bebidas");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acrescimos",
                table: "Hamburguers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Enderecos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "Bebidas",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Bebidas",
                keyColumn: "Sabor",
                keyValue: null,
                column: "Sabor",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Sabor",
                table: "Bebidas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
