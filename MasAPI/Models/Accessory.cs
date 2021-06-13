using System.Collections;
using System.Collections.Generic;

namespace MasAPI.Models
{
    public class Accessory
    {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}