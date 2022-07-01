using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCursosOnline.Migrations
{
    public partial class SeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedule",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
