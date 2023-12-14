using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name ="List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }
    }
}
