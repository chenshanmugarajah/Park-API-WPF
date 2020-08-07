using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Animal
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalFact { get; set; }
        public decimal? AnimalWeightTons { get; set; }
        public string AnimalDiet { get; set; }
        public int? ParkId { get; set; }

        public virtual Park Park { get; set; }
    }
}
