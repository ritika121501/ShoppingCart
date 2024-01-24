//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ShoppingCart.Models
//{
//    public class ShoppingCart
//    {
//        //Doth migration
//        //Repo - shopping cart
//        public int Id { get; set; }
        
//        public int ProductId { get; set; }
//        [ForeignKey("ProductId")]
//        [ValidateNever]
//        public Product Product { get; set; }
//        //Range validation 1-10
//        public int Count { get; set; }
        
//        public string ApplicationUserId { get; set; }
//        [ForeignKey("ApplicationUserId")]
//        [ValidateNever]
//        public ApplicationUser ApplicationUser { get; set; }
//    }
//}
