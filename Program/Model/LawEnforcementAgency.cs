using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class LawEnforcementAgency
    {
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public string Jurisdiction { get; set; }
        public Int64 ContactInfo { get; set; }
        public List<Officer> Officers { get; set; }

        public LawEnforcementAgency(int agencyID, string agencyName, string jurisdiction, long contactInfo, List<Officer> officers)
        {
            AgencyID = agencyID;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            ContactInfo = contactInfo;
            Officers = officers;
        }
    }
}
