namespace MasAPI.Models
{
    public class Referee
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
        public string IdNumber { get; set; }
    }
}