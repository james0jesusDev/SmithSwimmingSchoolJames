using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmithSwimmingSchoolJames.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tarde2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_progressReports_Coachs_CoachId",
                table: "progressReports");

            migrationBuilder.DropForeignKey(
                name: "FK_progressReports_Students_StudentId",
                table: "progressReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_progressReports",
                table: "progressReports");

            migrationBuilder.RenameTable(
                name: "progressReports",
                newName: "ProgressReports");

            migrationBuilder.RenameIndex(
                name: "IX_progressReports_StudentId",
                table: "ProgressReports",
                newName: "IX_ProgressReports_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_progressReports_CoachId",
                table: "ProgressReports",
                newName: "IX_ProgressReports_CoachId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgressReports",
                table: "ProgressReports",
                column: "ProgressReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Coachs_CoachId",
                table: "ProgressReports",
                column: "CoachId",
                principalTable: "Coachs",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressReports_Students_StudentId",
                table: "ProgressReports",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Coachs_CoachId",
                table: "ProgressReports");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressReports_Students_StudentId",
                table: "ProgressReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgressReports",
                table: "ProgressReports");

            migrationBuilder.RenameTable(
                name: "ProgressReports",
                newName: "progressReports");

            migrationBuilder.RenameIndex(
                name: "IX_ProgressReports_StudentId",
                table: "progressReports",
                newName: "IX_progressReports_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgressReports_CoachId",
                table: "progressReports",
                newName: "IX_progressReports_CoachId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_progressReports",
                table: "progressReports",
                column: "ProgressReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_progressReports_Coachs_CoachId",
                table: "progressReports",
                column: "CoachId",
                principalTable: "Coachs",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_progressReports_Students_StudentId",
                table: "progressReports",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
