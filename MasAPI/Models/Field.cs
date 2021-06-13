using System.Collections;
using System.Collections.Generic;

namespace MasAPI.Models
{
    //Klasa przypadku uzycia
    public class Field
    {
        public int FieldId { get; set; }
        public int SeatQuantity { get; set; }
        public string Name { get; set; }

        public ICollection<Match> Matches{ get; set; }
        public ICollection<Training> Trainings { get; set; }

        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}