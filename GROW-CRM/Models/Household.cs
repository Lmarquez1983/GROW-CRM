using System.Collections.Generic;

namespace GROW_CRM.Models
{
    public class Household
    {
        //Constructor
        Household()
        {
            Members = new HashSet<Member>();
            HouseholdDocuments = new HashSet<HouseholdDocument>();
            HouseholdNotifications = new HashSet<HouseholdNotification>();
            Orders = new HashSet<Order>();
        }

        //Fields
        public int ID { get; set; }

        public int StreetNumber { get; set; }

        public string StreetName { get; set; }

        public int? AptNumber { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public int YearlyIncome { get; set; }
        
        public bool LICOVerified { get; set; }

        //Foreign Keys
        public int ProvinceID { get; set; }

        public Province Province { get; set; }

        //O:M Relationships

        public ICollection<Member> Members { get; set; }

        public ICollection<HouseholdDocument> HouseholdDocuments { get; set; }

        public ICollection<HouseholdNotification> HouseholdNotifications { get; set; }

        public ICollection<Order> Orders { get; set; } 
    }
}