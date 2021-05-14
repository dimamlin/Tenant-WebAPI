using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Migrations
{
    public partial class AddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentsId",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_ApartmentsId",
                table: "Tenant",
                column: "ApartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Apartments_ApartmentsId",
                table: "Tenant",
                column: "ApartmentsId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Apartments_ApartmentsId",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_ApartmentsId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ApartmentsId",
                table: "Tenant");
        }
    }
}
