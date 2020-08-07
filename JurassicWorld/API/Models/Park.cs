using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Park
    {
        public Park()
        {
            Animal = new HashSet<Animal>();
        }

        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public string ParkDescription { get; set; }
        public string ParkLocation { get; set; }
        public int? ParkCapacity { get; set; }

        public virtual ICollection<Animal> Animal { get; set; }
    }
}
