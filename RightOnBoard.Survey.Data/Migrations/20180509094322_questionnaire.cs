using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RightOnBoard.Survey.Data.Migrations
{
    public partial class questionnaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DriverName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverQuestionGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DriverId = table.Column<string>(nullable: true),
                    QuestionGroupId = table.Column<string>(nullable: true),
                    QuestionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverQuestionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    QuestionGroupDescription = table.Column<string>(nullable: true),
                    QuestionGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OptionChoiceId = table.Column<string>(nullable: true),
                    QuestionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    QuestionAnswerRequired = table.Column<bool>(nullable: true),
                    QuestionName = table.Column<string>(nullable: true),
                    QuestionNumber = table.Column<string>(nullable: true),
                    QuestionSequence = table.Column<int>(nullable: true),
                    QuestionText = table.Column<string>(nullable: true),
                    QuestionTypeId = table.Column<string>(nullable: true),
                    SurveyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    QuestionTypeHasChoices = table.Column<bool>(nullable: true),
                    QuestionTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ExitMessage = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    WelcomeMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AnswerNumeric = table.Column<int>(nullable: true),
                    AnswerText = table.Column<string>(nullable: true),
                    AnswerYn = table.Column<bool>(nullable: true),
                    QuestionOptionId = table.Column<string>(nullable: true),
                    UnitOfMeasureId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_QuestionOptions_QuestionOptionId",
                        column: x => x.QuestionOptionId,
                        principalTable: "QuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionOptionId",
                table: "Answers",
                column: "QuestionOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "DriverQuestionGroup");

            migrationBuilder.DropTable(
                name: "QuestionGroup");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "QuestionOptions");
        }
    }
}
