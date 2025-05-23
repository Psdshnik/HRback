using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class workGroupUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_working_groups_WorkingGroupId1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_WorkingGroupId1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "WorkingGroupId1",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkingGroupId1",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_WorkingGroupId1",
                table: "users",
                column: "WorkingGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_users_working_groups_WorkingGroupId1",
                table: "users",
                column: "WorkingGroupId1",
                principalTable: "working_groups",
                principalColumn: "id");
        }
    }
}
