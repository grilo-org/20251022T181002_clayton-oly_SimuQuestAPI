using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimuQuestAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimulatedResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExamId = table.Column<int>(type: "integer", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Pontuacao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulatedResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimulatedResults_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnsweredQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    SimulatedResultId = table.Column<int>(type: "integer", nullable: false),
                    Acertou = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnsweredQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnsweredQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnsweredQuestion_SimulatedResults_SimulatedResultId",
                        column: x => x.SimulatedResultId,
                        principalTable: "SimulatedResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OptionId = table.Column<int>(type: "integer", nullable: false),
                    AnsweredQuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedOption_AnsweredQuestion_AnsweredQuestionId",
                        column: x => x.AnsweredQuestionId,
                        principalTable: "AnsweredQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedOption_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnsweredQuestion_QuestionId",
                table: "AnsweredQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnsweredQuestion_SimulatedResultId",
                table: "AnsweredQuestion",
                column: "SimulatedResultId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedOption_AnsweredQuestionId",
                table: "SelectedOption",
                column: "AnsweredQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedOption_OptionId",
                table: "SelectedOption",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SimulatedResults_ExamId",
                table: "SimulatedResults",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedOption");

            migrationBuilder.DropTable(
                name: "AnsweredQuestion");

            migrationBuilder.DropTable(
                name: "SimulatedResults");
        }
    }
}
