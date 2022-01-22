using System;
using System.Collections.Generic;

namespace GROW_CRM.Models
{
    public class Notification
    {
        //Constructor
        Notification()
        {
            HouseholdNotifications = new HashSet<HouseholdNotification>();
        }

        //Fields
        public int ID { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        //Foreign Keys
        public int NotificationTypeID { get; set; }

        public NotificationType NotificationType { get; set; }

        //O:M Relationships

        public ICollection<HouseholdNotification> HouseholdNotifications { get; set; }
    }
}