using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieShopDLL.Entities
{
    public class Customer : AbstractEntity
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual Address Address { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}