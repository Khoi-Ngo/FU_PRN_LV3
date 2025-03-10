using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pre_maritalCounSeling.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update_reduce_qrzdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quiz_Result_Detail");

            migrationBuilder.AddColumn<bool>(
                name: "DoHaveFeedback",
                table: "Quiz_Result",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FeedBack",
                table: "Quiz_Result",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "No feedback provided yet!");

            migrationBuilder.AddColumn<string>(
                name: "RecommendedAnswerData",
                table: "Quiz_Result",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAnswerData",
                table: "Quiz_Result",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoHaveFeedback",
                table: "Quiz_Result");

            migrationBuilder.DropColumn(
                name: "FeedBack",
                table: "Quiz_Result");

            migrationBuilder.DropColumn(
                name: "RecommendedAnswerData",
                table: "Quiz_Result");

            migrationBuilder.DropColumn(
                name: "UserAnswerData",
                table: "Quiz_Result");

            migrationBuilder.CreateTable(
                name: "Quiz_Result_Detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quiz_result_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recommended_answer = table.Column<string>(type: "text", nullable: false),
                    user_answer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("quiz_result_detail_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "quiz_result_detail_quiz_result_id_foreign",
                        column: x => x.quiz_result_id,
                        principalTable: "Quiz_Result",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_Result_Detail_quiz_result_id",
                table: "Quiz_Result_Detail",
                column: "quiz_result_id");
        }
    }
}
