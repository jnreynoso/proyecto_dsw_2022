namespace SistemaCursosOnline.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public string? turn { get; set; }
        public string? beginning_hour { get; set; }
        public string? finish_hour { get; set; }
        public string? duration { get; set; }
    }
}
