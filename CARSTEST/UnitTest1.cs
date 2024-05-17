using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using CARS.Repository;
using CARS.Model;
namespace CARSTEST
{
    public class Tests
    {

        CrimeAnalysisService service = new CrimeAnalysisService();

        [Test]
        public void Test_CreateIncident_Success()
        {
            // Arrange
            Incident incident = new Incident();

            incident.incidentType = "Robbery";
            incident.incidentDate = DateTime.Parse("2024-04-12");
            incident.location = "Indore";
            incident.description = "Robbery at DMart";
            incident.status = "Open";
            incident.victimID = 101;
            incident.suspectID = 202;

            bool result = service.CreateIncident(incident);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_UpdateIncidentStatus()
        {

            string status = "Closed";
            int incidentID = 1;
            bool result = service.UpdateIncidentStatus(status, incidentID);


            // Assert
            Assert.IsTrue(result);
        }
    }
}