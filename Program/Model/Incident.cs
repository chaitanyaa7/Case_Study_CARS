using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Incident
    {
        private int incidentID;
        private string incidentType;
        private DateTime incidentDate;
        private int victimID;
        private int suspectID;
        private string description;
        private string status;
        private string location;
        private List<Victim> victims;
        private List<Suspect> suspects;
        private LawEnforcementAgency agency;

        public Incident() { }
        public Incident(int _incidentID, string _incidentType, DateTime _incidentDate,string _location, string _description, string _status, int _victimID, int _suspectID)
        {
            this.incidentID = _incidentID;
            this.incidentType = _incidentType;
            this.incidentDate = _incidentDate;
            this.location = _location;
            this.description = _description;
            this.status = _status;
            this.victimID = _victimID;
            this.suspectID = _suspectID;
        }

        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        public string IncidentType
        {
            get { return incidentType; }
            set { incidentType = value; }
        }

        public DateTime IncidentDate
        {
            get { return incidentDate; }
            set { incidentDate = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int VictimID
        {
            get { return victimID; }
            set { victimID = value; }
        }
        public int SuspectID
        {
            get { return suspectID; }
            set { suspectID = value; }
        }

        public override string ToString()
        {
            return $"IncidentID: {incidentID}\n" +
                   $"IncidentType: {incidentType}\n" +
                   $"IncidentDate: {incidentDate}\n" +
                   $"Location: {location}\n" +
            $"Description: {description}\n" +
                   $"Status: {status}\n" +
                   $"VictimID: {victimID}\n" +
                   $"SuspectID: {suspectID}\n"+
                   "..........................\n";
        }



    }
}
