using Microsoft.EntityFrameworkCore.Migrations;

namespace Microdev.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BossId = table.Column<int>(nullable: true),
                    Salary = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Programming" },
                    { 2, "Fasico" },
                    { 3, "IT" },
                    { 4, "BFC" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BossId", "DepartmentId", "FirstName", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, 2, 1, "Zahra", "Bayat", 2000m },
                    { 2, 1, 1, "Ali", "Bayat", 3000m },
                    { 3, 1, 1, "Sara", "Masoodi", 3000m },
                    { 4, 1, 1, "Mehdi", "Mohamadi", 3000m },
                    { 5, 1, 1, "Amin", "Sadeghi", 1000m },
                    { 6, 2, 1, "Shadi", "Sohbati", 1000m },
                    { 7, 2, 2, "Somaye", "Mahdavi", 1000m },
                    { 8, 2, 2, "Maryam", "Zahedi", 1000m },
                    { 9, 2, 2, "Mary", "Zibayee", 1000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
