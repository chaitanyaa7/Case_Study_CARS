using CARS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.MainApp
{
    internal class MainModule
    {
        CrimeAnalysisSeriveLayer seriveLayer;
        public MainModule()
        {
            seriveLayer = new CrimeAnalysisSeriveLayer();
        }
        public void run()
        {
            
            
            while (true)
            {
                

                Console.WriteLine("----------Crime Analysis and Reporting System-------");
                Console.WriteLine("1. Create a new incident");
                Console.WriteLine("2. Update the status of an incident");
                Console.WriteLine("3. Get a list of incidents within a date range");
                Console.WriteLine("4. Search for incidents based on various criteria");
                Console.WriteLine("5. Generate incident reports");
                Console.WriteLine("6. Manage Reports/Cases");
                Console.WriteLine("7. Exit");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    Console.ReadKey();
                    continue;
                }

                if (choice == 7)
                {
                    break;
                }
                Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            seriveLayer.CreateIncident();
                            break;
                        case 2:
                            seriveLayer.UpdateIncidentStatus();
                            break;
                        case 3:
                            seriveLayer.GetIncidentsInDateRange();
                            break;
                        case 4:
                            seriveLayer.SearchIncidents();
                            break;
                        case 5:
                            seriveLayer.GenerateIncidentReport();
                            break;
                        case 6:
                        AcessReport();
                            break ;
                    
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();


            }
        }

        private void AcessReport()
        {
           

            Console.WriteLine("Methods to gain information about the Cases/Reports");
            Console.WriteLine("Enter Choice from below options:");
            Console.WriteLine("1. Create a new case and associate it with incidents");
            Console.WriteLine("2. Get details of a specific case");
            Console.WriteLine("3. Update case details");
            Console.WriteLine("4. Get a list of all cases");
            Console.Write("Choice: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                return;
            }

            switch (choice)
            {
                case 1:
                    seriveLayer.CreateCase();
                    break;
                case 2:
                    seriveLayer.GetCaseDetails();
                    break;
                case 3:
                    seriveLayer.UpdateCaseDetails();
                    break;
                case 4:
                    seriveLayer.GetAllCases();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }
    }
}
