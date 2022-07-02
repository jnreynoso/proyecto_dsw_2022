namespace SistemaCursosOnline.Models
{
    public class TbUser
    {
        public int id { get; set; }
        public String names { get; set; }
        public String dni { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public int attempts { get; set; }
    }
}
