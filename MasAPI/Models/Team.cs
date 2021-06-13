using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasAPI.Models
{
    //Klasa przypadku uzycia
    public class Team
    {
        public int TeamId { get; set; }
        
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Rocznik powinien składać się z 4 cyfr")]
        public string Year { get; set; }
        
        [EnumDataType(typeof(Leagues), ErrorMessage = "Nazwa tej ligi nie istnieje w systemie")]
        public Leagues League { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}