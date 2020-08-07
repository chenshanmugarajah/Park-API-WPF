using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public partial class Park
    {
        public override string ToString()
        {
            return $"Park: {ParkName} with capacity {ParkCapacity}";
        }
    }
    public partial class Animal
    {
        public override string ToString()
        {
            return $"Animal: {AnimalName} weighing {AnimalWeightTons} tons";
        }

    }
}
