using System;
using System.ComponentModel.DataAnnotations;

namespace MasAPI.Models
{
    //Klasa przypadku uzycia
    public class Match
    {
        public int MatchId { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
        public Field Field { get; set; }
        public int FieldId { get; set; }
        public Referee Referee { get; set; }

        [EnumDataType(typeof(CreationStages), ErrorMessage = "Nazwa stanu jest niepoprawna.")]
        public CreationStages Status { get; set; }
        public DateTime DateSince { get; set; }
        public DateTime DateUntil { get; set; }
        public string EnemyName { get; set; }

        public int getDuration()
        {
            TimeSpan duration = DateUntil - DateSince;
            return duration.Minutes;
        }
    }
}