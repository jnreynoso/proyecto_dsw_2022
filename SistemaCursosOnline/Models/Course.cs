namespace SistemaCursosOnline.Models
{
    public class Course
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string? description { get; set; }
        public string? photo_url { get; set; }
        public int scheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
