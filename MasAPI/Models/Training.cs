using System;
using System.Collections;
using System.Collections.Generic;

namespace MasAPI.Models
{
    //Klasa przypadku uzycia
    public class Training
    {
        public int TrainingId { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
        public Field Field { get; set; }
        public int FieldId { get; set; }
        
        public DateTime DateSince { get; set; }
        public DateTime DateUntil { get; set; }

        public ICollection<Accessory> Accessories { get; set; }
        
        public int getDuration()
        {
            TimeSpan duration = DateUntil - DateSince;
            return duration.Minutes;
        }
    }
}