using System.ComponentModel.DataAnnotations;

namespace MasAPI.Models
{
    public class Player
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
        [EnumDataType(typeof(Predispoitions), ErrorMessage = "Nie można określić lepszej nogi taką wartością")]
        public Predispoitions BetterLeg { get; set; }
        
        //Deklaracja pól do Speed, Accuracy, Strength z ograniczeniem od 1-10
        
        [Range(0,10, ErrorMessage = "Wartosc pola {0} powinna zawierać się w przedziale od {1} do {2}")]
        public int? Speed { get; set; }
        
        [Range(0,10, ErrorMessage = "Wartosc pola {0} powinna zawierać się w przedziale od {1} do {2}")]
        public int? Accuracy { get; set; }
        
        [Range(0,10, ErrorMessage = "Wartosc pola {0} powinna zawierać się w przedziale od {1} do {2}")]
        public int? Strength { get; set; }
        
        public float Weight { get; set; }
    }
}