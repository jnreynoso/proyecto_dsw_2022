namespace SistemaCursosOnline.Models
{
    public class CoursesGroupByTeacher
    {
        public int? teacherId { get; set; }
        public string nameTeacher { get; set; }
        public string photoTeacher { get; set; }
        public List<TeacherCourse>? teacherAndCourse { get; set; }
    }
}
