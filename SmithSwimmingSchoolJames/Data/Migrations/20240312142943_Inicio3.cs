using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmithSwimmingSchoolJames.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicio3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CoachId",
                table: "Courses",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Coachs_CoachId",
                table: "Courses",
                column: "CoachId",
                principalTable: "Coachs",
                principalColumn: "CoachId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Coachs_CoachId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CoachId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Courses");
        }
    }
}
