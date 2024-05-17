using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    internal class Evidence
    {
        public int EvidenceID { get; set; }
        public string Description { get; set; }
        public string LocationFound { get; set; }
        public Incident Incident { get; set; }


    }
}
