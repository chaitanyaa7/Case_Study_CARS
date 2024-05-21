using CARS.Model;
using CARS.Repository;
using CARS.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    internal class CrimeAnalysisSeriveLayer

    {
        ICrimeAnalysisService service;

        public CrimeAnalysisSeriveLayer()
        {
            service = new CrimeAnalysisService();
        }
        public void CreateIncident()
        {
           Incident incident = new Incident();
           

            Console.WriteLine("Please enter the IncidentType (e.g., Robbery, Homicide, Theft):");
            incident.IncidentType = Console.ReadLine();

            Console.WriteLine("Please enter the IncidentDate (e.g., 2024-05-16):");
            incident.IncidentDate = DateTime.Parse(Console.ReadLine());

           
            Console.WriteLine("Please enter the Location (string format):");
            incident.Location = Console.ReadLine();

            
            Console.WriteLine("Please enter the Description:");
            incident.Description = Console.ReadLine();

            
            Console.WriteLine("Please enter the Status (e.g., Open, Closed, Under Investigation):");
            incident.Status = Console.ReadLine();

           
           

           
            if (service.CreateIncident(incident))
            {
                Console.WriteLine("Incident created successfully");
            }
            else { Console.WriteLine("Failed"); }
            return;
        }
        public void UpdateIncidentStatus()
        {
            try
            {
                Console.WriteLine("Here is the record of Incident Table");
                List<Incident> incidents = service.GetAllInci();
                foreach (Incident inc in incidents)
                {
                    Console.WriteLine(inc.ToString());
                }
                Console.WriteLine("Please enter the Status (e.g., Open, Closed, Under Investigation):");
                string status = Console.ReadLine();

                Console.WriteLine("Please enter the Incident ID");
                int incidentID = int.Parse(Console.ReadLine());

                if (!service.CheckIfIncidentIDexists(incidentID))
                {
                    throw new IncidentNumberNotFoundException("Invalid Incident ID");
                }

                if (service.UpdateIncidentStatus(status, incidentID))
                {
                    Console.WriteLine("Your record has been successfully updated");
                }
                else { Console.WriteLine("Failed"); }
                return;
            }
            catch (IncidentNumberNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
        public void GetIncidentsInDateRange()
        {
            Console.WriteLine("Please enter the Start date (e.g., 2024-05-16):");
            DateTime start = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Start date (e.g., 2024-05-16):");
            DateTime end = DateTime.Parse(Console.ReadLine());

            List<Incident> incidents= service.GetIncidentsInDateRange(start, end);  
            if(incidents.Count > 0) {
                foreach (Incident inc in incidents)
                {
                    Console.WriteLine(inc.ToString());
                }
                
            }
            else Console.WriteLine("No such records found"); return;


        }
        public void SearchIncidents()
        {
            Console.WriteLine("Here is the record of Incident Table");
            List<Incident> incidents = service.GetAllInci();
            foreach (Incident inc in incidents)
            {
                Console.WriteLine(inc.ToString());
            }
            Console.WriteLine("Please enter the IncidentType (e.g., Robbery, Homicide, Theft):");
            string incidentType = Console.ReadLine();
            List<Incident> incidentss = service.SearchIncidents(incidentType);
            if (incidentss.Count > 0)
            {
                foreach (Incident inc in incidents)
                {
                    Console.WriteLine(inc.ToString());
                }

            }
            else Console.WriteLine("No such records found"); return;

        }
        public void GenerateIncidentReport()
        {
            Incident incident= new Incident();  
            Console.WriteLine("Please enter the Description:");
            incident.Description = Console.ReadLine();


            Console.WriteLine("Please enter the Status (e.g., Open, Closed, Under Investigation):");
            incident.Status = Console.ReadLine();

            Console.WriteLine("Please enter the IncidentDate (e.g., 2024-05-16):");
            incident.IncidentDate = DateTime.Parse(Console.ReadLine());

            if (service.GenerateIncidentReport(incident)!=null)
            {
                Console.WriteLine("Your record has been successfully entered");
            }
            else Console.WriteLine("Failed");
            return;
        }
        public void CreateCase()
        {
           Case caseDetails= new Case();
            Console.WriteLine("Please enter the Case Status:");
            caseDetails.CaseStatus = Console.ReadLine();

            
            Console.WriteLine("Please enter the IncidentID:");
            caseDetails.IncidentID = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Please enter the OfficerID:");
         
            caseDetails.OfficerID = int.Parse(Console.ReadLine());

           
            Console.WriteLine("Please enter the CaseDescription:");
            caseDetails.CaseDescription = Console.ReadLine();
            
            if(service.CreateCase(caseDetails.CaseDescription,caseDetails.CaseStatus,caseDetails.IncidentID,caseDetails.OfficerID)!=null)
            {
                Console.WriteLine("Case created successfully");
            }
            else Console.WriteLine("Failed");
            return;
        }
        public void GetCaseDetails()
        {
            
            Console.WriteLine("Please enter the Case ID:");
            int caseID = int.Parse(Console.ReadLine());
            if (service.GetCaseDetails(caseID) != null)
            {
                Console.WriteLine( service.GetCaseDetails(caseID).ToString());
            }
            else Console.WriteLine("Enter the right details");
            return;

        }
        public void UpdateCaseDetails()
        {
            Console.WriteLine("Here is the record of Case Table");
            List<Case> cases = service.GetAllCases();
            foreach (Case c in cases)
            {
                Console.WriteLine(c.ToString());
            }
            Case caseDetails = new Case();
            Console.WriteLine("Please enter the Case Status:");
            caseDetails.CaseStatus = Console.ReadLine();


            Console.WriteLine("Please enter the IncidentID:");
            caseDetails.IncidentID = int.Parse(Console.ReadLine());


            Console.WriteLine("Please enter the OfficerID:");

            caseDetails.OfficerID = int.Parse(Console.ReadLine());


            Console.WriteLine("Please enter the CaseDescription:");
            caseDetails.CaseDescription = Console.ReadLine();

            if (service.UpdateCaseDetails(caseDetails)==true)
            {
                Console.WriteLine("Updated successfully");
            }
            else Console.WriteLine("Failed");
            return;
        }
        public void GetAllCases()
        {
            List<Case> cases = service.GetAllCases();
            foreach(Case c in  cases) {
                Console.WriteLine(c.ToString());
            }
        }


    }
}
