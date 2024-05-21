using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Report
    {
        private int reportID;
        private int incidentID;
        private int reportingOfficer;
        private DateTime reportDate;
        private string reportDetails;
        private string status;

        public int ReportID {  get { return reportID; } set {  reportID = value; } }
        public int Incident { get {  return incidentID; } set {  incidentID = value; } }

        public int Officer { get {  return reportingOfficer; } set { reportingOfficer = value; } }
        public DateTime ReportDate { get {  return reportDate; } set { reportDate = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string ReportDetails { get {  return reportDetails; } set { reportDetails = value; } }

        public Report() { }

       public Report(int incident, int reportingOfficer, DateTime dateTime, string reportDetails, string status ) {
           this.reportDate = dateTime;
            this.incidentID = incident;
            this.reportingOfficer = reportingOfficer;  
            this.reportDetails= reportDetails;
            this.status = status;
        }


        public override string ToString()
        {
            return $"report ID: {reportID}\n" +
                   $"Incident ID: {incidentID}\n" +
                   $"Officer Id: {reportingOfficer}\n" +
                   $"Report Date: {reportDate}\n" +
                   $"Status: {status}\n" +
                   $"Report Details: {reportDetails}\n" +
                   "..........................\n";
        }


    }
}
