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
        public int incidentID { get; set; }
        public string incidentType { get; set; }
        public DateTime incidentDate { get; set; }
      
        public int victimID {  get; set; }
        public int suspectID {  get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string location { get; set; }

        public List<Victim> victims { get; set; }
        public List<Suspect> suspects { get; set; }
        public LawEnforcementAgency agency { get; set; }

        public Incident() { }
        public Incident(int _incidentID, string _incidentType, DateTime _incidentDate,string _location, string _description, string _status, int _victimID, int _suspectID)
        {
            incidentID = _incidentID;
            incidentType = _incidentType;
            incidentDate = _incidentDate;
            location = _location;
            description = _description;
            status = _status;
            victimID = _victimID;
            suspectID = _suspectID;
        }

        public override string ToString()
        {
            return $"IncidentID: {incidentID} " +
                   $"IncidentType: {incidentType} " +
                   $"IncidentDate: {incidentDate} " +
                   $"Location: {location} " +
            $"Description: {description} " +
                   $"Status: {status} " +
                   $"VictimID: {victimID} " +
                   $"SuspectID: {suspectID}";
        }

    }
}
