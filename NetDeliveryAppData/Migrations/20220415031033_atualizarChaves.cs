using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetDeliveryAppData.Migrations
{
    public partial class atualizarChaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_TipoId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsuarioId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_TipoId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UsuarioId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AspNetUserRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Enderecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "Numero",
                table: "Enderecos",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "AspNetUserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "AspNetUserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_TipoId",
                table: "AspNetUserRoles",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UsuarioId",
                table: "AspNetUserRoles",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_TipoId",
                table: "AspNetUserRoles",
                column: "TipoId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UsuarioId",
                table: "AspNetUserRoles",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
