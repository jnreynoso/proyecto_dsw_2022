namespace SistemaCursosOnline.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string names { get; set; }
        public string dni { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Gender Gender { get; set; }
        public int genderId { get; set; }
        public string cv_url { get; set; }

    }
}
