using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmithSwimmingSchoolJames.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentUser",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoachUser",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentUser",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CoachUser",
                table: "Coachs");
        }
    }
}
