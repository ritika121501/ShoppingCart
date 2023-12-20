using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage = "Length should not be greater than 30")]
        public string Name { get; set; }
        [Range(1,50,ErrorMessage="Display order must be between 1-49")]
        public int DisplayOrder { get; set; }
    }
}
