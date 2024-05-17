using CARS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    internal interface ICrimeAnalysisService
    {
        bool CreateIncident(Incident incident);
        bool UpdateIncidentStatus(string status, int incidentID);
        List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        List<Incident> SearchIncidents(string criteria);
        Report GenerateIncidentReport(Incident incident);
        Case CreateCase(string caseDes, string caseStatus, int iid, int oid);
        Case GetCaseDetails(int caseId);
        bool UpdateCaseDetails(Case caseObj);
        List<Case> GetAllCases();

        List<Incident> GetAllInci();

        bool CheckIfIncidentIDexists(int inci);
    }
}
