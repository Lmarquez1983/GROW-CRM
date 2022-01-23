using GROW_CRM.Models.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GROW_CRM.Models
{
    public class Member : Auditable 
    {

        //Constructor
        Member()
        {
            DietaryRestrictionMembers = new HashSet<DietaryRestrictionMember>();
            Orders = new HashSet<Order>();
        }

        //Fields

        public int ID { get; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string DOB { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        //Foreign Keys        

        public int GenderID { get; set; }

        public Gender Gender { get; set; }

        public int HouseholdID { get; set; }

        public Household Household { get; set; }

        public int IncomeSituationID { get; set; }        

        public IncomeSituation IncomeSituation { get; set; }

        //O:M Relationships        

        public ICollection<DietaryRestrictionMember> DietaryRestrictionMembers { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}