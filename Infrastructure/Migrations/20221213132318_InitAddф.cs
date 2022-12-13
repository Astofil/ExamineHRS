using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitAddф : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmployeeId",
                table: "JobHistories",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Employees_EmployeeId",
                table: "JobHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Employees_EmployeeId",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_EmployeeId",
                table: "JobHistories");
        }
    }
}
