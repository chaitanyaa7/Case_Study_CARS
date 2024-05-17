using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Officer
    {
        public int OfficerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BadgeNumber { get; set; }
        public string Rank { get; set; }
        public string ContactInfo { get; set; }
        public LawEnforcementAgency Agency { get; set; }
    }
}
