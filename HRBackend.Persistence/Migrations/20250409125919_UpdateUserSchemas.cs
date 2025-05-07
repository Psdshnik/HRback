using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HRBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dict_status_candidata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dict_status_candidata", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "type_socail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_type_socail", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "work_shedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_work_shedule", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "working_groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_working_groups", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personal_info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    surname = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    middlename = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    email = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    phone = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    name_socail = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    date_add = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    TypeSocailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personal_info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_info_type_socail_TypeSocailId",
                        column: x => x.TypeSocailId,
                        principalTable: "type_socail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    surname = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    middlename = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    login = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    password = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    WorkScheduleId = table.Column<int>(type: "int", nullable: false),
                    WorkingGroupId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_work_shedule_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "work_shedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_working_groups_WorkingGroupId",
                        column: x => x.WorkingGroupId,
                        principalTable: "working_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date_add = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    PersonalInfoId = table.Column<int>(type: "int", nullable: false),
                    WorkScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emploees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_personal_info_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "personal_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_work_shedule_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "work_shedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateUp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusCandidataIdId = table.Column<int>(type: "int", nullable: false),
                    WorkScheduleId = table.Column<int>(type: "int", nullable: false),
                    WorkingGroupId = table.Column<int>(type: "int", nullable: false),
                    PersonalInfoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_candidates_dict_status_candidata_StatusCandidataIdId",
                        column: x => x.StatusCandidataIdId,
                        principalTable: "dict_status_candidata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidates_personal_info_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "personal_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidates_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidates_work_shedule_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "work_shedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidates_working_groups_WorkingGroupId",
                        column: x => x.WorkingGroupId,
                        principalTable: "working_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "check",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date_check = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    @event = table.Column<string>(name: "event", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_check", x => x.Id);
                    table.ForeignKey(
                        name: "FK_check_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_Id",
                table: "candidates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_PersonalInfoId",
                table: "candidates",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_StatusCandidataIdId",
                table: "candidates",
                column: "StatusCandidataIdId");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_UserId",
                table: "candidates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_WorkingGroupId",
                table: "candidates",
                column: "WorkingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_WorkScheduleId",
                table: "candidates",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_check_UserId",
                table: "check",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_dict_status_candidata_Id",
                table: "dict_status_candidata",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_Id",
                table: "employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_PersonalInfoId",
                table: "employees",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_WorkScheduleId",
                table: "employees",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_info_Id",
                table: "personal_info",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_info_TypeSocailId",
                table: "personal_info",
                column: "TypeSocailId");

            migrationBuilder.CreateIndex(
                name: "IX_type_socail_Id",
                table: "type_socail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_users_id",
                table: "users",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_users_WorkingGroupId",
                table: "users",
                column: "WorkingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_users_WorkScheduleId",
                table: "users",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_work_shedule_Id",
                table: "work_shedule",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_working_groups_id",
                table: "working_groups",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidates");

            migrationBuilder.DropTable(
                name: "check");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "dict_status_candidata");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "personal_info");

            migrationBuilder.DropTable(
                name: "work_shedule");

            migrationBuilder.DropTable(
                name: "working_groups");

            migrationBuilder.DropTable(
                name: "type_socail");
        }
    }
}
