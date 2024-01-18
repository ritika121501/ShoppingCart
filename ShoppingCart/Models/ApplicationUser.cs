using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int ApplicationUserNameId { get; set; }
        public string ApplicationUserName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? postalCode{ get; set; }
    }
}
