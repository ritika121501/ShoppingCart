using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Company
    {
        //Chinduja/Mani/Arasi/Keerthi
        //Migration
        //CRUD - create Controller
        //views for all operations
        //Datables for showing all company together,  buttons for edit and delete/ Create new Company

        //Silpa/Devanshi/Neethu/Sudha
        
        [Key]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string CompanyName { get; set; }

        [MaxLength(1000)]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        [MaxLength(10)]
        public long PhoneNumber { get; set; }
    }
}
