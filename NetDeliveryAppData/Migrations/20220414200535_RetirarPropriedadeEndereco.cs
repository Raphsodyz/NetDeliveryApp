using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetDeliveryAppData.Migrations
{
    public partial class RetirarPropriedadeEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Enderecos_EnderecoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EnderecoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "AspNetUsers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EnderecoId",
                table: "AspNetUsers",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enderecos_EnderecoId",
                table: "AspNetUsers",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
