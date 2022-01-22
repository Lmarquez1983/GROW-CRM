using System.Collections.Generic;

namespace GROW_CRM.Models
{
    public class Item
    {
        //Constructor
        public Item()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        //Fields 
        public int ID { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        //O:M Relationships
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}