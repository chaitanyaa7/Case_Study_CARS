using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
    public class Officer
    {
        private int officerID;
        private string firstName;
        private string lastName;
        private string badgeNumber;
        private string rank;
        private Int64 contactInfo;
        private LawEnforcementAgency agency;

        public int OfficerID
        {
            get { return officerID; }
            set { officerID = value; }
        }
        public string FirstName {  get { return firstName; } set {  firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string BadgeNumber { get {  return badgeNumber; } set {  badgeNumber = value; } }
        public string Rank { get { return rank; } set {  rank = value; } }
        public Int64 ContactInfo { get {  return contactInfo; } set {  contactInfo = value; } }

        public Officer() { }

        public Officer(int officerID, string firstName, string lastName, string badgeNumber, string rank, long contactInfo)
        {
            this.officerID = officerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.badgeNumber = badgeNumber;
            this.rank = rank;
            this.contactInfo = contactInfo;
         
        }

        public override string ToString()
        {
            return $"Officer ID: {officerID}\n" +
                  $"First Name: {firstName}\n" +
                  $"Last Name: {lastName}\n" +
                  $"Badge Number: {badgeNumber}\n" +
                  $"Rank: {rank}\n" +
                  "..........................\n";
        }
    }
}
