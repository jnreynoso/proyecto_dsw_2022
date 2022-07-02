namespace SistemaCursosOnline.Models
{
    public class Alumn
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string dni { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Gender Gender { get; set; }
        public int genderId { get; set; }
    }
}
