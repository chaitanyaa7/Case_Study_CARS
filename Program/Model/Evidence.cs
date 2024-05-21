using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    internal class Evidence
    {
        private int evidenceID;
        private string description;
        private string locationFound;
        private Incident incident;

        public int EvidenceID
        {
            get { return evidenceID; }
            set { evidenceID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string LocationFound
        {
            get { return locationFound; }
            set { locationFound = value; }
        }
        public Incident Incident
        {
            get { return incident; }
            set { incident = value; }
        }
        public Evidence() { }

        public Evidence(int evidenceID, string description, string locationFound, Incident incident)
        {
            this.evidenceID = evidenceID;
            this.description = description;
            this.locationFound = locationFound;
            this.incident = incident;
           
        }

        public override string ToString()
        {
            return $"Evidence ID: {evidenceID}\n" +
                   $"Description ID: {description}\n" +
                   $"Location found: {locationFound}\n" +
                   "..........................\n";
        }
    }
}
