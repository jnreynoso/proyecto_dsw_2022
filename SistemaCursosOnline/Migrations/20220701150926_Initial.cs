using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCursosOnline.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "id", "description", "name", "scheduleId" },
                values: new object[,]
                {
                    { 5, "Odoo", "Python", 1 },
                    { 6, "Indices, Consultas, DDL", "MySql", 2 },
                    { 7, "Estructuras de datos", "Java", 3 },
                    { 8, "Servicios", "ITIL v4", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_scheduleId",
                table: "Courses",
                column: "scheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
