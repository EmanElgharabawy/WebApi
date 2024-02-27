using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Createdepartment1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dept_Id",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Dept_Id",
                table: "Student",
                column: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_Dept_Id",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_Dept_Id",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Student_Dept_Id",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Dept_Id",
                table: "Student");
        }
    }
}
