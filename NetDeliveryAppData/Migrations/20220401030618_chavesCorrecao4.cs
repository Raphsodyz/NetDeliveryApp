using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetDeliveryAppData.Migrations
{
    public partial class chavesCorrecao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidosId",
                table: "Clientes",
                type: "int",
                nullable: true);
        }
    }
}
