using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCursosOnline.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    beginning_hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    finish_hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TbUser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    attempts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genderId = table.Column<int>(type: "int", nullable: true),
                    cv_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teacher_Gender_genderId",
                        column: x => x.genderId,
                        principalTable: "Gender",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courses_Schedule_scheduleId",
                        column: x => x.scheduleId,
                        principalTable: "Schedule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherId = table.Column<int>(type: "int", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourse", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Teacher_teacherId",
                        column: x => x.teacherId,
                        principalTable: "Teacher",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TeacherScheduling",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherId = table.Column<int>(type: "int", nullable: true),
                    scheduleId = table.Column<int>(type: "int", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherScheduling", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeacherScheduling_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TeacherScheduling_Schedule_scheduleId",
                        column: x => x.scheduleId,
                        principalTable: "Schedule",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TeacherScheduling_Teacher_teacherId",
                        column: x => x.teacherId,
                        principalTable: "Teacher",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 9, "Masculino" },
                    { 10, "Femenino" },
                    { 11, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "id", "beginning_hour", "duration", "finish_hour", "turn" },
                values: new object[,]
                {
                    { 1, "8am", "2 horas", "10am", "Lunes - Miércoles - Viernes" },
                    { 2, "1pm", "2 horas", "3pm", "Lunes - Miércoles - Viernes" },
                    { 3, "8am", "3 horas", "11am", "Martes - Jueves - Sábado" },
                    { 4, "4pm", "4 horas", "8pm", "Martes - Jueves - Sábado" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "id", "description", "name", "photo_url", "scheduleId" },
                values: new object[,]
                {
                    { 5, "Odoo", "Python", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Python.svg/1200px-Python.svg.png", 1 },
                    { 6, "Indices, Consultas, DDL", "MySql", "https://d1.awsstatic.com/asset-repository/products/amazon-rds/1024px-MySQL.ff87215b43fd7292af172e2a5d9b844217262571.png", 2 },
                    { 7, "Estructuras de datos", "Java", "https://dev.java/assets/images/java-logo-vert-blk.png", 3 },
                    { 8, "Servicios", "ITIL v4", "https://egaconsultores.com/wp-content/uploads/2020/05/itil-v4-foundation.png", 4 }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "id", "cv_url", "dni", "email", "genderId", "names", "phone", "photo_url" },
                values: new object[,]
                {
                    { 12, "http://jnreynoso.github.io/CV.pdf", "72494607", "jreynoso.mena@gmail.com", 9, "Jean Reynoso", "923359438", null },
                    { 13, "http://jnreynoso.github.io/CV.pdf", "00494607", "pjreynoso.mena@gmail.com", 9, "Pablo Reynoso", "923354545", null }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourse",
                columns: new[] { "id", "courseId", "teacherId" },
                values: new object[,]
                {
                    { 18, 5, 12 },
                    { 19, 6, 12 },
                    { 20, 7, 13 },
                    { 21, 8, 13 }
                });

            migrationBuilder.InsertData(
                table: "TeacherScheduling",
                columns: new[] { "id", "courseId", "scheduleId", "teacherId" },
                values: new object[,]
                {
                    { 14, 5, 1, 12 },
                    { 15, 5, 2, 12 },
                    { 16, 6, 1, 12 },
                    { 17, 6, 2, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_scheduleId",
                table: "Courses",
                column: "scheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_genderId",
                table: "Teacher",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_courseId",
                table: "TeacherCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_teacherId",
                table: "TeacherCourse",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherScheduling_courseId",
                table: "TeacherScheduling",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherScheduling_scheduleId",
                table: "TeacherScheduling",
                column: "scheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherScheduling_teacherId",
                table: "TeacherScheduling",
                column: "teacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbUser");

            migrationBuilder.DropTable(
                name: "TeacherCourse");

            migrationBuilder.DropTable(
                name: "TeacherScheduling");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
