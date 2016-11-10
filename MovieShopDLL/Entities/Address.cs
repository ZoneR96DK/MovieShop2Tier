using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopDLL.Entities
{
    public class Address // : AbstractEntity
    {
        [Key, ForeignKey("Customer")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required]
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        //[Required]
        public virtual Customer Customer { get; set; }

        public override string ToString()
        {
            return $"{StreetName} {StreetNumber}, {PostalCode} {City}, {Country}";
        }
    }
}