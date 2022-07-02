namespace SistemaCursosOnline.Models
{
    public class Enrollment
    {
        public int id { get; set; }
        public Teacher Teacher { get; set; }
        public int teacherId { get; set; }
        public Course Course { get; set; }
        public int courseId { get; set; }


    }
}
