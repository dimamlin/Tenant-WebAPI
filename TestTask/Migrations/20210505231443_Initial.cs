using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roomsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flatNunmber = table.Column<int>(type: "int", nullable: false),
                    isTenant = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
