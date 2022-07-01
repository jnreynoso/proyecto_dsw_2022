namespace SistemaCursosOnline.Models
{
    public class Courses
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string? description { get; set; }
        public int scheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
