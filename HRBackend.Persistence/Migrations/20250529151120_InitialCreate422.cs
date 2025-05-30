using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate422 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidates_users_UserId",
                table: "candidates");

            migrationBuilder.AlterColumn<string>(
                name: "WorkSchedule",
                table: "candidates",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "candidates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidates_UserId1",
                table: "candidates",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_candidates_users_UserId",
                table: "candidates",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_candidates_users_UserId1",
                table: "candidates",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidates_users_UserId",
                table: "candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_candidates_users_UserId1",
                table: "candidates");

            migrationBuilder.DropIndex(
                name: "IX_candidates_UserId1",
                table: "candidates");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "candidates");

            migrationBuilder.AlterColumn<int>(
                name: "WorkSchedule",
                table: "candidates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_candidates_users_UserId",
                table: "candidates",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
