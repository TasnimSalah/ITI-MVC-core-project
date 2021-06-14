using Microsoft.EntityFrameworkCore.Migrations;

namespace Lec1.Migrations
{
    public partial class deptcrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentCourses_Departments_DepartmentsId",
                table: "DepartmentCourses");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentCourses_DepartmentsId",
                table: "DepartmentCourses");

            migrationBuilder.DropColumn(
                name: "DepartmentsId",
                table: "DepartmentCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentCourses_Departments_DeptId",
                table: "DepartmentCourses",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentCourses_Departments_DeptId",
                table: "DepartmentCourses");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId",
                table: "DepartmentCourses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_DepartmentsId",
                table: "DepartmentCourses",
                column: "DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentCourses_Departments_DepartmentsId",
                table: "DepartmentCourses",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
