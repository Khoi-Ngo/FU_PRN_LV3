using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pre_maritalCounSeling.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback_Type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("feedback_type_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Post_Type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("post_type_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    duration = table.Column<long>(type: "bigint", nullable: true),
                    duration_unit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    avg_time_completed = table.Column<double>(type: "float", nullable: true),
                    tags = table.Column<string>(type: "text", nullable: true),
                    difficulty = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pass_score = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("quiz_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule_Type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    buffer = table.Column<long>(type: "bigint", nullable: true),
                    buffer_unit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("schedule_type_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Service_Category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    category_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("service_category_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User_Detail_Category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_detail_category_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "text", nullable: false),
                    QuizId = table.Column<long>(type: "bigint", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    recommended_answer = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("question_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "question_id_foreign",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    employee_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    role_id = table.Column<short>(type: "smallint", nullable: false),
                    request_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    application_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    background_img = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    partner_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_partner_id_foreign",
                        column: x => x.partner_id,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_role_id_foreign",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Question_Option",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "text", nullable: false),
                    is_correct = table.Column<bool>(type: "bit", nullable: false),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    explanation = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("question_option_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "question_option_id_foreign",
                        column: x => x.question_id,
                        principalTable: "Question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    type_id = table.Column<long>(type: "bigint", nullable: false),
                    view = table.Column<long>(type: "bigint", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("post_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "post_type_id_foreign",
                        column: x => x.type_id,
                        principalTable: "Post_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "post_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quiz_Result",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    score = table.Column<long>(type: "bigint", nullable: false),
                    quiz_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    quiz_result_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    time_completed = table.Column<double>(type: "float", nullable: false),
                    attempt_time = table.Column<long>(type: "bigint", nullable: false),
                    suggestion_content = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("quiz_result_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "quiz_result_quiz_id_foreign",
                        column: x => x.quiz_id,
                        principalTable: "Quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "quiz_result_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    commission = table.Column<double>(type: "float", nullable: true),
                    commission_rate = table.Column<double>(type: "float", nullable: true),
                    estimated_duration = table.Column<double>(type: "float", nullable: true),
                    duration_unit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    expert_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    service_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avg_rating = table.Column<double>(type: "float", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("service_id_primary", x => x.id);
                    table.CheckConstraint("Max_value_avg_rating", "avg_rating <= 5");
                    table.CheckConstraint("Min_value_avg_rating", "avg_rating >= 0");
                    table.CheckConstraint("Min_value_commission_rate", "commission_rate >= 0");
                    table.ForeignKey(
                        name: "service_category_id_foreign",
                        column: x => x.category_id,
                        principalTable: "Service_Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "service_expert_id_foreign",
                        column: x => x.expert_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    summary = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    refered_link = table.Column<string>(type: "text", nullable: true),
                    attached_document = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_detail_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_detail_category_id_foreign",
                        column: x => x.category_id,
                        principalTable: "User_Detail_Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_detail_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quiz_Result_Detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quiz_result_id = table.Column<long>(type: "bigint", nullable: false),
                    user_answer = table.Column<string>(type: "text", nullable: false),
                    recommended_answer = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    rating = table.Column<short>(type: "smallint", nullable: true),
                    type_id = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    service_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("feedback_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "feedback_service_id_foreign",
                        column: x => x.service_id,
                        principalTable: "Service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "feedback_type_id_foreign",
                        column: x => x.type_id,
                        principalTable: "Feedback_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_id = table.Column<long>(type: "bigint", nullable: false),
                    completed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    time = table.Column<DateTime>(type: "datetime", nullable: false),
                    schedule_type_id = table.Column<long>(type: "bigint", nullable: false),
                    expert_note = table.Column<string>(type: "text", nullable: true),
                    refered_link = table.Column<string>(type: "text", nullable: true),
                    customer_note = table.Column<string>(type: "text", nullable: true),
                    expert_response = table.Column<string>(type: "text", nullable: true),
                    rescheduled_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    rescheduled_count = table.Column<short>(type: "smallint", nullable: false),
                    appointment_mode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    priority = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    reminder_sent = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("schedule_id_primary", x => x.id);
                    table.CheckConstraint("CK_RescheduledCount_Max", "rescheduled_count <= 2");
                    table.ForeignKey(
                        name: "schedule_schedule_type_id_foreign",
                        column: x => x.schedule_type_id,
                        principalTable: "Schedule_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "schedule_service_id_foreign",
                        column: x => x.service_id,
                        principalTable: "Service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attached_File",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    refered_link = table.Column<string>(type: "text", nullable: false),
                    feedback_id = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attached_file_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "attached_file_feedback_id_foreign",
                        column: x => x.feedback_id,
                        principalTable: "Feedback",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "attached_file_schedule_id_foreign",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule_User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: false),
                    schedule_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("schedule_user_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "schedule_user_customer_id_foreign",
                        column: x => x.customer_id,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "schedule_user_schedule_id_foreign",
                        column: x => x.schedule_id,
                        principalTable: "Schedule",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attached_File_feedback_id",
                table: "Attached_File",
                column: "feedback_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attached_File_ScheduleId",
                table: "Attached_File",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_service_id",
                table: "Feedback",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_type_id",
                table: "Feedback",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "feedback_type_name_unique",
                table: "Feedback_Type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_type_id",
                table: "Post",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_user_id",
                table: "Post",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "post_type_name_unique",
                table: "Post_Type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Option_question_id",
                table: "Question_Option",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_Result_quiz_id",
                table: "Quiz_Result",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_Result_user_id",
                table: "Quiz_Result",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_Result_Detail_quiz_result_id",
                table: "Quiz_Result_Detail",
                column: "quiz_result_id");

            migrationBuilder.CreateIndex(
                name: "role_name_unique",
                table: "Role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_schedule_type_id",
                table: "Schedule",
                column: "schedule_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_service_id",
                table: "Schedule",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_User_customer_id",
                table: "Schedule_User",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_User_schedule_id",
                table: "Schedule_User",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_category_id",
                table: "Service",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_expert_id",
                table: "Service",
                column: "expert_id");

            migrationBuilder.CreateIndex(
                name: "service_category_name_unique",
                table: "Service_Category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_partner_id",
                table: "User",
                column: "partner_id",
                unique: true,
                filter: "[partner_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "user_user_name_unique",
                table: "User",
                column: "user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Detail_category_id",
                table: "User_Detail",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Detail_user_id",
                table: "User_Detail",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_detail_category_name_unique",
                table: "User_Detail_Category",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attached_File");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Question_Option");

            migrationBuilder.DropTable(
                name: "Quiz_Result_Detail");

            migrationBuilder.DropTable(
                name: "Schedule_User");

            migrationBuilder.DropTable(
                name: "User_Detail");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Post_Type");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Quiz_Result");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "User_Detail_Category");

            migrationBuilder.DropTable(
                name: "Feedback_Type");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Schedule_Type");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Service_Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
