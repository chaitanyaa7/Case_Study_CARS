using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Case
    {
        private int caseID;
        private string caseStatus;
        private int incidentID;
        private int officerID;
        private string caseDescription;
        public Case() { }

        public Case(int _caseID,string _caseStatus, int _incidentID,int _officerID,string _caseDescription)
        {
            caseID=_caseID;
            caseStatus = _caseStatus;
            incidentID = _incidentID;
            officerID = _officerID;
            caseDescription = _caseDescription;
        }

        public int CaseID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }
        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }
        public string CaseStatus
        {
            get { return caseStatus; }
            set { caseStatus = value; }
        }
        public string CaseDescription
        {
            get { return caseDescription; }
            set { caseDescription = value; }
        }
        public int OfficerID
        {
            get { return officerID; }
            set { officerID = value; }
        }

        public override string ToString()
        {
            return $"CaseID: {caseID}\n" +
                $"CaseNo: {caseStatus}\n" +
                   $"IncidentID: {incidentID}\n" +
                   $"OfficerID: {officerID}\n" +
                   $"CaseDescription: {caseDescription}";
        }





    }
}
