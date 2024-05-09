using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CourseTemplate");

            migrationBuilder.EnsureSchema(
                name: "Course");

            migrationBuilder.EnsureSchema(
                name: "Learner");

            migrationBuilder.EnsureSchema(
                name: "Session");

            migrationBuilder.CreateTable(
                name: "CourseTemplates",
                schema: "CourseTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTemplateStatus = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DurationInWeeks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Learners",
                schema: "Learner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Forename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityPlanTemplates",
                schema: "CourseTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityPlanTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityPlanTemplates_CourseTemplates_CourseTemplateId",
                        column: x => x.CourseTemplateId,
                        principalSchema: "CourseTemplate",
                        principalTable: "CourseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleTemplates",
                schema: "CourseTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriteriaTemplates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DurationInWeeks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleTemplates_CourseTemplates_CourseTemplateId",
                        column: x => x.CourseTemplateId,
                        principalSchema: "CourseTemplate",
                        principalTable: "CourseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionPlanTemplates",
                schema: "CourseTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionPlanTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionPlanTemplates_CourseTemplates_CourseTemplateId",
                        column: x => x.CourseTemplateId,
                        principalSchema: "CourseTemplate",
                        principalTable: "CourseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseStatus = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalSchema: "Learner",
                        principalTable: "Learners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningPlans",
                schema: "Learner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningPlans_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalSchema: "Learner",
                        principalTable: "Learners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTemplates",
                schema: "CourseTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityPlanTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleTemplateIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityTemplates_ActivityPlanTemplates_ActivityPlanTemplateId",
                        column: x => x.ActivityPlanTemplateId,
                        principalSchema: "CourseTemplate",
                        principalTable: "ActivityPlanTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionTemplates",
                schema: "CourseTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionPlanTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionType = table.Column<int>(type: "int", nullable: false),
                    ScheduleDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CohortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeetingLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionTemplates_SessionPlanTemplates_SessionPlanTemplateId",
                        column: x => x.SessionPlanTemplateId,
                        principalSchema: "CourseTemplate",
                        principalTable: "SessionPlanTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleStatus = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    AwardingOrganisation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Course",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionType = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CohortId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MeetingLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Course",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPlanTemplates_CourseTemplateId",
                schema: "CourseTemplate",
                table: "ActivityPlanTemplates",
                column: "CourseTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTemplates_ActivityPlanTemplateId",
                schema: "CourseTemplate",
                table: "ActivityTemplates",
                column: "ActivityPlanTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LearnerId",
                schema: "Course",
                table: "Courses",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningPlans_LearnerId",
                schema: "Learner",
                table: "LearningPlans",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId",
                schema: "Course",
                table: "Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleTemplates_CourseTemplateId",
                schema: "CourseTemplate",
                table: "ModuleTemplates",
                column: "CourseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPlanTemplates_CourseTemplateId",
                schema: "CourseTemplate",
                table: "SessionPlanTemplates",
                column: "CourseTemplateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CourseId",
                schema: "Session",
                table: "Sessions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionTemplates_SessionPlanTemplateId",
                schema: "CourseTemplate",
                table: "SessionTemplates",
                column: "SessionPlanTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTemplates",
                schema: "CourseTemplate");

            migrationBuilder.DropTable(
                name: "LearningPlans",
                schema: "Learner");

            migrationBuilder.DropTable(
                name: "Modules",
                schema: "Course");

            migrationBuilder.DropTable(
                name: "ModuleTemplates",
                schema: "CourseTemplate");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Session");

            migrationBuilder.DropTable(
                name: "SessionTemplates",
                schema: "CourseTemplate");

            migrationBuilder.DropTable(
                name: "ActivityPlanTemplates",
                schema: "CourseTemplate");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Course");

            migrationBuilder.DropTable(
                name: "SessionPlanTemplates",
                schema: "CourseTemplate");

            migrationBuilder.DropTable(
                name: "Learners",
                schema: "Learner");

            migrationBuilder.DropTable(
                name: "CourseTemplates",
                schema: "CourseTemplate");
        }
    }
}
