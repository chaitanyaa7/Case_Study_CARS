using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class LawEnforcementAgency
    {
        private int agencyID;
        private string agencyName;
        private string jurisdiction;
        private Int64 contactInfo;
        private List<Officer> officers;
        
        public LawEnforcementAgency() { }
        public LawEnforcementAgency(int agencyID, string agencyName, string jurisdiction, long contactInfo, List<Officer> officers)
        {
            this.agencyID = agencyID;
            this.agencyName = agencyName;
            this.jurisdiction = jurisdiction;
            this.contactInfo = contactInfo;
            this.officers = officers;
        }

        public int AgencyID
        {
            get { return agencyID; }
            set {agencyID = value; }
        }
        public int AgencyName
        {
            get { return agencyID; }
            set { agencyID = value; }
        }
        public string Jurisdiction
        {
            get { return jurisdiction; }
            set { jurisdiction = value; }
        }
        public Int64 ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }
        public List<Officer> Officers
        {
            get { return officers; }
            set { officers = value; }
        }

        public override string ToString()
        {
            return $"AgencyID: {agencyID}\n" +
                $"Agency Name: {agencyName}\n" +
                   $"Jurisdiction: {jurisdiction}\n" +
                   $"Contact Information: {contactInfo}\n";
        }

    }
}
