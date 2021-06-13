using System;
using System.Collections;
using System.Collections.Generic;

namespace MasAPI.Models
{
    public class Fan
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
        public string FanCardId { get; set; }
        public DateTime  JoinDate { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        //Metoda do generowania id karty kibica - nie przypadek uzycia
        public static string GenerateFanCardId()
        {
            return "";
        }
        
    }
}