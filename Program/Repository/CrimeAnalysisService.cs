using CARS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Repository
{
    public class CrimeAnalysisService : ICrimeAnalysisService
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public CrimeAnalysisService()
        {
            sqlConnection = new SqlConnection("Server=LAPTOP-F5CGII6O;Database=CARS;Trusted_Connection=True");
            cmd = new SqlCommand();
        }

        public bool CreateIncident(Incident incident)
        {
            cmd.CommandText = "INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID) VALUES (@IncidentType, @IncidentDate, @Location, @Description, @Status, @VictimID, @SuspectID)";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            
                cmd.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                cmd.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                cmd.Parameters.AddWithValue("@Location", incident.Location);
                cmd.Parameters.AddWithValue("@Description", incident.Description);
                cmd.Parameters.AddWithValue("@Status", incident.Status);
                cmd.Parameters.AddWithValue("@VictimID", incident.VictimID);
                cmd.Parameters.AddWithValue("@SuspectID", incident.SuspectID);
                
                return cmd.ExecuteNonQuery() > 0;
            
        }

        public bool UpdateIncidentStatus( string status, int incidentID)
        {
            cmd.CommandText = "UPDATE Incidents SET Status = @Status WHERE IncidentID = @IncidentID";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@IncidentID", incidentID);
            sqlConnection.Close();
                return cmd.ExecuteNonQuery() > 0;
            
        }

        public List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            cmd.CommandText = "SELECT * FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate";
            List<Incident> incidents = new List<Incident>();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Incident incident = new Incident
                        {
                            IncidentID = (int)reader["IncidentID"],
                            IncidentType = (string)reader["IncidentType"],
                            IncidentDate = (DateTime)reader["IncidentDate"],
                            Location = (string)reader["Location"],
                            Description = (string)reader["Description"],
                            Status = (string)reader["Status"],
                            VictimID = (int)reader["VictimID"],
                            SuspectID = (int)reader["SuspectID"]
                        };
                        incidents.Add(incident);
                    }
                }
           sqlConnection.Close();
            return incidents;
        }

        public List<Incident> SearchIncidents(string incidentType)
        {
            cmd.CommandText = "SELECT * FROM Incidents WHERE IncidentType = @IncidentType";
            List<Incident> incidents = new List<Incident>();
            
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@IncidentType", incidentType);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Incident incident = new Incident
                        {
                            IncidentID = (int)reader["IncidentID"],
                            IncidentType = (string)reader["IncidentType"],
                            IncidentDate = (DateTime)reader["IncidentDate"],
                            Location = (string)reader["Location"],
                            Description = (string)reader["Description"],
                            Status = (string)reader["Status"],
                            VictimID = (int)reader["VictimID"],
                            SuspectID = (int)reader["SuspectID"]
                        };
                        incidents.Add(incident);
                    }
                }
            
                sqlConnection.Close();
            return incidents;
        }

        public Report GenerateIncidentReport(Incident incident)
        {
            
            Report report = new Report();
           
            report.Status=incident.Status;
            report.ReportDate = incident.IncidentDate;
            report.ReportDetails = incident.Description;


            cmd.CommandText = "INSERT INTO Reports ( ReportDate, ReportDetails, Status) VALUES ( @ReportDate, @ReportDetails, @Status)";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
                
                cmd.Parameters.AddWithValue("@ReportDate", report.ReportDate);
                cmd.Parameters.AddWithValue("@ReportDetails", report.ReportDetails);
                cmd.Parameters.AddWithValue("@Status", report.Status);
            sqlConnection.Close();
                if (cmd.ExecuteNonQuery() > 0)
                {
                return report;
                }
            

            return null;
        }

        public Case CreateCase(string caseDes, string caseStatus, int iid,int oid )
        {
            Case newCase = new Case();
            newCase.CaseStatus = caseStatus;
            newCase.CaseDescription= caseDes; ;
            newCase.IncidentID = iid; 
            newCase.OfficerID = oid;

           

            cmd.CommandText = "INSERT INTO Cases (CaseStatus,CaseDescription,IncidentID,OfficerID) VALUES (@cStatus,@des,@IID,OID)";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@des", newCase.CaseDescription);
            cmd.Parameters.AddWithValue("@cStatus", newCase.CaseStatus );
            cmd.Parameters.AddWithValue("@IID", newCase.IncidentID);
            cmd.Parameters.AddWithValue("@OID", newCase.OfficerID);
            sqlConnection.Close();
            if (cmd.ExecuteNonQuery() > 0) return newCase;
            return null;

        
        }

        public Case GetCaseDetails(int caseID)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM Cases WHERE CaseID = @CaseeID";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@CaseeID", caseID);
            
            using (SqlDataReader reader = cmd.ExecuteReader()) { 
                if (reader.Read())
                {
                    Case caseDetails = new Case();

                    caseDetails.CaseID = (int)reader["CaseID"];
                        caseDetails.CaseDescription = (string)reader["CaseDescription"];
                        caseDetails.IncidentID = (int)reader["IncidentID"];
                        caseDetails.OfficerID = (int)reader["OfficerID"];
                        caseDetails.CaseStatus = (string)reader["CaseNo"];
                    
                    sqlConnection.Close();
                    return caseDetails;
                }
            }

           
            return null;
        }

        public bool UpdateCaseDetails(Case caseDetails)
        {
            string query = "UPDATE Cases SET CaseDescription = @Description, IncidentID=IID, OfficerId=OID,CaseStatus=CStatus WHERE CaseID = @cID";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@Description", caseDetails.CaseDescription);
            cmd.Parameters.AddWithValue("@CID", caseDetails.CaseID);
            cmd.Parameters.AddWithValue("@IID", caseDetails.IncidentID);
            cmd.Parameters.AddWithValue("@OID", caseDetails.OfficerID);
            cmd.Parameters.AddWithValue("@CStatus", caseDetails.OfficerID);
            sqlConnection.Close();
            return cmd.ExecuteNonQuery() > 0;
            
        }

        public List<Case> GetAllCases()
        {
            List<Case> cases = new List<Case>();
            cmd.CommandText = "SELECT * FROM Cases";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Case caseDetails = new Case
                        {
                            CaseID = (int)reader["CaseID"],
                            CaseDescription = (string)reader["CaseDescription"],
                            IncidentID= (int)reader["IncidentID"],
                            OfficerID= (int)reader["OfficerID"],
                            CaseStatus= (string)reader["CaseStatus"]
                        };
                        cases.Add(caseDetails);
                    }
                }

            sqlConnection.Close();
            return cases;
        }

        public List<Incident> GetAllInci()
        {
            cmd.CommandText = "SELECT * FROM Incidents ";
            List<Incident> incidents = new List<Incident>();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Incident incident = new Incident
                    {
                        IncidentID = (int)reader["IncidentID"],
                        IncidentType = (string)reader["IncidentType"],
                        IncidentDate = (DateTime)reader["IncidentDate"],
                        Location = (string)reader["Location"],
                        Description = (string)reader["Description"],
                        Status = (string)reader["Status"],
                        VictimID = (int)reader["VictimID"],
                        SuspectID = (int)reader["SuspectID"]
                    };
                    incidents.Add(incident);
                }
            }

            sqlConnection.Close();
            return incidents;
        }

        public bool CheckIfIncidentIDexists(int inci)
        {
            cmd.CommandText = "SELECT * FROM Incidents WHERE IncidentID = @IID";
            List<Incident> incidents = new List<Incident>();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@IID", inci);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Incident incid = new Incident
                    {
                        IncidentID = (int)reader["IncidentID"],
                        IncidentType = (string)reader["IncidentType"],
                        IncidentDate = (DateTime)reader["IncidentDate"],
                        Location = (string)reader["Location"],
                        Description = (string)reader["Description"],
                        Status = (string)reader["Status"],
                        VictimID = (int)reader["VictimID"],
                        SuspectID = (int)reader["SuspectID"]
                    };
                    incidents.Add(incid);
                }
            }

            sqlConnection.Close();
            if( incidents.Count > 0 )
            {
                return true;
            }
            return false;
        }




    }
}

    