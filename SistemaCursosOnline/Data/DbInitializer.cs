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
                new Course { id = 5, name = "Python", description = "Odoo", scheduleId = 1, photo_url = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Python.svg/1200px-Python.svg.png" },
                new Course { id = 6, name = "MySql", description = "Indices, Consultas, DDL", scheduleId = 2, photo_url = "https://d1.awsstatic.com/asset-repository/products/amazon-rds/1024px-MySQL.ff87215b43fd7292af172e2a5d9b844217262571.png" },
                new Course { id = 7, name = "Java", description = "Estructuras de datos", scheduleId = 3, photo_url = "https://dev.java/assets/images/java-logo-vert-blk.png" },
                new Course { id = 8, name = "ITIL v4", description = "Servicios", scheduleId = 4, photo_url = "https://egaconsultores.com/wp-content/uploads/2020/05/itil-v4-foundation.png" },
            });


            modelBuilder.Entity<Gender>().HasData(new Gender[]
            {
                new Gender {id = 9, name = "Masculino" },
                new Gender {id = 10, name = "Femenino" },
                new Gender {id = 11, name = "Otro" },

            });

            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher {id = 12, names = "Jean Reynoso", email = "jreynoso.mena@gmail.com", dni = "72494607", genderId = 9, phone = "923359438", cv_url = "http://jnreynoso.github.io/CV.pdf"},
                new Teacher {id = 13, names = "Pablo Reynoso", email = "pjreynoso.mena@gmail.com", dni = "00494607", genderId = 9, phone = "923354545", cv_url = "http://jnreynoso.github.io/CV.pdf"}

            });

            modelBuilder.Entity<TeacherScheduling>().HasData(new TeacherScheduling[]
            {
                new TeacherScheduling {id = 14, courseId = 5, scheduleId = 1, teacherId = 12},
                new TeacherScheduling {id = 15, courseId = 5, scheduleId = 2, teacherId = 12},
                new TeacherScheduling {id = 16, courseId = 6, scheduleId = 1, teacherId = 12},
                new TeacherScheduling {id = 17, courseId = 6, scheduleId = 2, teacherId = 12}

            });

            modelBuilder.Entity<TeacherCourse>().HasData(new TeacherCourse[]
            {
                new TeacherCourse {id = 18, courseId = 5, teacherId = 12},
                new TeacherCourse {id = 19, courseId = 6, teacherId = 12},
                new TeacherCourse {id = 20, courseId = 7, teacherId = 13},
                new TeacherCourse {id = 21, courseId = 8, teacherId = 13}
            });
        }
    }
}
