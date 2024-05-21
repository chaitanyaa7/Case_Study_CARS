using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Model
{
   public class Victim
    {
        private int victimID;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private Int64 contactInfo;

        public int VictimID { get {  return victimID; } set {  victimID = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public DateTime DateOfBirth { get {  return dateOfBirth; } set {  dateOfBirth = value; } }
        public string Gender { get {  return gender; } set {  gender = value; } }
        public Int64 ContactInfo { get {  return contactInfo; } set {  contactInfo = value; } }

        public Victim() { }

        public Victim(int victimID, string firstName, string lastName, DateTime dateOfBirth, string gender, Int64 contactInfo)
        {
            this.victimID = victimID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.contactInfo = contactInfo;
        }

        public override string ToString()
        {
            return $"Victim ID: {victimID}\n" +
                   $"First Name: {firstName}\n" +
                   $"Last Name: {lastName}\n" +
                   $"Date of Birth: {dateOfBirth}\n" +
            $"Gender: {gender}\n" +
                   $"Contact information: {contactInfo}\n" +
                   "..........................\n";
        }
    }
}
