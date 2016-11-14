using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieShopDLL.Entities
{
    public class Genre : AbstractEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}