using Microsoft.EntityFrameworkCore.Migrations;

namespace EnrollmentService.Migrations
{
    public partial class AlterColumnEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoursePrice",
                table: "Courses");

            migrationBuilder.AddColumn<float>(
                name: "Invoice",
                table: "Enrollments",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoice",
                table: "Enrollments");

            migrationBuilder.AddColumn<double>(
                name: "CoursePrice",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
