using SistemaCursosOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaCursosOnline.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Schedule>().HasData(new Schedule[]
            {
                new Schedule { id = 1,  turn = "Lunes - Miércoles - Viernes", beginning_hour = "8am", finish_hour = "10am", duration = "2 horas" },
                new Schedule { id = 2, turn = "Lunes - Miércoles - Viernes", beginning_hour = "1pm", finish_hour = "3pm", duration = "2 horas" },
                new Schedule { id = 3, turn = "Martes - Jueves - Sábado", beginning_hour = "8am", finish_hour = "11am", duration = "3 horas" },
                new Schedule { id = 4, turn = "Martes - Jueves - Sábado", beginning_hour = "4pm", finish_hour = "8pm", duration = "4 horas" }
            });

            modelBuilder.Entity<Course>().HasData(new Course[]
            {
                new Course { id = 5, name = "Python", description = "Odoo", scheduleId = 1 },
                new Course { id = 6, name = "MySql", description = "Indices, Consultas, DDL", scheduleId = 2 },
                new Course { id = 7, name = "Java", description = "Estructuras de datos", scheduleId = 3 },
                new Course { id = 8, name = "ITIL v4", description = "Servicios", scheduleId = 4 },
            });
        }
    }
}
