using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace diplom.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specialization",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    specialization_name = table.Column<string>(type: "text", nullable: false),
                    qualification = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("specialization_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    subject_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("subject_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("teacher_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    course = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    specialization_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("group_pkey", x => x.id);
                    table.ForeignKey(
                        name: "group_specialization_id_fkey",
                        column: x => x.specialization_id,
                        principalTable: "specialization",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subject_specialization",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    specialization_id = table.Column<int>(type: "integer", nullable: false),
                    subject_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("subject_specialization_pkey", x => x.id);
                    table.ForeignKey(
                        name: "subject_specialization_specialization_id_fkey",
                        column: x => x.specialization_id,
                        principalTable: "specialization",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "subject_specialization_subject_id_fkey",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "teacher_subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    subject_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("teacher_subject_pkey", x => x.id);
                    table.ForeignKey(
                        name: "teacher_subject_subject_id_fkey",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "teacher_subject_teacher_id_fkey",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "load",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    subject_id = table.Column<int>(type: "integer", nullable: false),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    first_semester_time = table.Column<int>(type: "integer", nullable: false),
                    second_semester_time = table.Column<int>(type: "integer", nullable: false),
                    theory_time = table.Column<int>(type: "integer", nullable: false),
                    practical_time = table.Column<int>(type: "integer", nullable: false),
                    lpz_one_time = table.Column<int>(type: "integer", nullable: true),
                    lpz_two_time = table.Column<int>(type: "integer", nullable: true),
                    consultation_time = table.Column<int>(type: "integer", nullable: true),
                    course_project_time = table.Column<int>(type: "integer", nullable: true),
                    all_hours_in_first_semester = table.Column<string>(type: "text", nullable: false),
                    all_hours_in_second_semester = table.Column<string>(type: "text", nullable: false),
                    total = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Load_pkey", x => x.id);
                    table.ForeignKey(
                        name: "load_group_id_fkey",
                        column: x => x.group_id,
                        principalTable: "group",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "load_subject_id_fkey",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "load_teacher_id_fkey",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_group_specialization_id",
                table: "group",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_group_id",
                table: "load",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_subject_id",
                table: "load",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_load_teacher_id",
                table: "load",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_subject_specialization_specialization_id",
                table: "subject_specialization",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_subject_specialization_subject_id",
                table: "subject_specialization",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_subject_subject_id",
                table: "teacher_subject",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_subject_teacher_id",
                table: "teacher_subject",
                column: "teacher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "load");

            migrationBuilder.DropTable(
                name: "subject_specialization");

            migrationBuilder.DropTable(
                name: "teacher_subject");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "specialization");
        }
    }
}
