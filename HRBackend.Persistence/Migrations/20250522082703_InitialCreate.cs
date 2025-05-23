using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_check_check_CheckId",
                table: "check");

            migrationBuilder.DropForeignKey(
                name: "FK_check_users_UserId1",
                table: "check");

            migrationBuilder.DropIndex(
                name: "IX_check_CheckId",
                table: "check");

            migrationBuilder.DropIndex(
                name: "IX_check_UserId1",
                table: "check");

            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "check");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "check");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckId",
                table: "check",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "check",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_check_CheckId",
                table: "check",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_check_UserId1",
                table: "check",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_check_check_CheckId",
                table: "check",
                column: "CheckId",
                principalTable: "check",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_check_users_UserId1",
                table: "check",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
