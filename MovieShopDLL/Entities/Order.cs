using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopDLL.Entities
{
    public class Order : AbstractEntity
    {
        //[Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        //[Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}