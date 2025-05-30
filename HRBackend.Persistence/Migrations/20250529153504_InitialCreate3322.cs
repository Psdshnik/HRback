using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidates_users_UserId1",
                table: "candidates");

            migrationBuilder.DropIndex(
                name: "IX_candidates_UserId1",
                table: "candidates");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "candidates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_candidates_users_UserId1",
                table: "candidates",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
