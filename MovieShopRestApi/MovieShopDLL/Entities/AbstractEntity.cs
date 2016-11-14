using System.ComponentModel.DataAnnotations;

namespace MovieShopDLL.Entities
{
    public abstract class AbstractEntity
    {
        [Key]
        public int Id { get; set; }
    }
}