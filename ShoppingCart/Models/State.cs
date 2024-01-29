using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }

    }
}
