using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HRBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:name_socail_enum", "instagram,linked_in,face_book,vk")
                .Annotation("Npgsql:Enum:name_work_schedule_enum", "office,hybrid,home")
                .Annotation("Npgsql:Enum:status_candidata_enum", "at_work,offer,accepted,rejected,under_review,interview,test_assignment")
                .Annotation("Npgsql:Enum:type_event_enum", "candidat,employes")
                .Annotation("Npgsql:Enum:user_roles_enum", "admin,hr");

            migrationBuilder.CreateTable(
                name: "dict_country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "working_groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_working_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "personal_info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    surname = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    middlename = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    email = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    phone = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    date_add = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    name_socail = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personal_info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personal_info_dict_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "dict_country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateUp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    WorkingGroupId = table.Column<int>(type: "int", nullable: false),
                    PersonalInfoId = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NameWorkSchedule = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_candidates_personal_info_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "personal_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidates_working_groups_WorkingGroupId",
                        column: x => x.WorkingGroupId,
                        principalTable: "working_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_add = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    PersonalInfoId = table.Column<int>(type: "integer", nullable: false),
                    work_schedule = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emploees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_personal_info_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "personal_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    WorkingGroupId = table.Column<int>(type: "int", nullable: false),
                    PersonalInfoId = table.Column<int>(type: "integer", nullable: false),
                    work_schedule = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_personal_info_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "personal_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_working_groups_WorkingGroupId",
                        column: x => x.WorkingGroupId,
                        principalTable: "working_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "check",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_check = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedId = table.Column<int>(type: "integer", nullable: false),
                    @event = table.Column<string>(name: "event", type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_check", x => x.Id);
                    table.ForeignKey(
                        name: "FK_check_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidates_Id",
                table: "candidates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_PersonalInfoId",
                table: "candidates",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_candidates_WorkingGroupId",
                table: "candidates",
                column: "WorkingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_check_UserId",
                table: "check",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_Id",
                table: "employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_PersonalInfoId",
                table: "employees",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_info_CountryId",
                table: "personal_info",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_personal_info_Id",
                table: "personal_info",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_users_Id",
                table: "users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_users_PersonalInfoId",
                table: "users",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_users_WorkingGroupId",
                table: "users",
                column: "WorkingGroupId");

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
                name: "users");

            migrationBuilder.DropTable(
                name: "personal_info");

            migrationBuilder.DropTable(
                name: "working_groups");

            migrationBuilder.DropTable(
                name: "dict_country");
        }
    }
}
