namespace SistemaCursosOnline.Models
{
    public class TeacherCourse
    {
        public int id { get; set; }
        public int? teacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? courseId { get; set; }
        public Course Course { get; set; }
    }
}
