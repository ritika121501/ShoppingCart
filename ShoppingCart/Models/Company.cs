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

        //Silpa/Mani/Neethu/Sudha

        //Register Page - rajee, Srivalli , Anitha, Chinduja
        //Add all missing fields
        //City, State , Country amke it drop down
        //City - Id, Name - Create Table
        //State - Id Name - Crete Table
        //SelectList Item and fetch it

        //Swarna , Raj Priya, Azim, Keerthi

        // A cart Option on main menu strip
        //On Clcik of the cart - open a new page
        // That page shoule hasve few DEatils like 
        //Product Id 
        //Invoice Controller
        //Invoice Table - Application Udser id, Id(PK), TotalPrice

        
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
       
		//[MaxLength(10, ErrorMessage = "Length should not be greater than 10")]
		public long PhoneNumber { get; set; }
    }
}
