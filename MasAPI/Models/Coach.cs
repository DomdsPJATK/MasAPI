using System.ComponentModel.DataAnnotations;

namespace MasAPI.Models
{
    public class Coach
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [EnumDataType(typeof(CoachCategories), ErrorMessage = "Taka kategoria trenerska nie istnieje")]
        public CoachCategories Category { get; set; }
        public float HourlyRate { get; set; }
        
    }
}