using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Report
    {
        public int reportID { get; set; }
        public Incident incidentID { get; set; }
        public Officer reportingOfficer { get; set; }
        public DateTime reportDate { get; set; }
        public string reportDetails { get; set; }
        public string status { get; set; }


    }
}
