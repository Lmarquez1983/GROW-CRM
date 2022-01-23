using GROW_CRM.Models.Utilities;
using System.Collections.Generic;

namespace GROW_CRM.Models
{
    public class Message : Auditable 
    {
        //Fields
        public int ID { get; set; }

        public string Text { get; set; }

        public System.DateTime Date { get; set; }

        //O:M Relationships
        public ICollection<Notification> Notifications { get; set; }
    }
}