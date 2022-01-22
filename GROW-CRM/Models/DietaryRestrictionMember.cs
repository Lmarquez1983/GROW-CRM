namespace GROW_CRM.Models
{
    public class DietaryRestrictionMember
    {
        //Fields
        public int ID { get; set; }

        //Foreign Keys

        public int MemberID { get; set; }

        public Member Member { get; set; }

        public int DietaryRestrictionID { get; set; }

        public DietaryRestriction DietaryRestriction { get; set; }
    }
}