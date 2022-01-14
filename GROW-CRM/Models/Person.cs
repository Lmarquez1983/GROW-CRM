using System.ComponentModel.DataAnnotations;

namespace GROW_CRM.Models
{
    abstract class Person
    {
        int ID { get; }

        [Required]
        [Display(Name = "First Name")]
        string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        string LastName { get; set; }

        string Email { get; set; }

        string Phone { get; set; }
    }
}