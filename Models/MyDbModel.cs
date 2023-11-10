using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class MyDbModel
    //MyDbModel item = new MyDbModel();
    //public void MyDbModel()
    {
        [Key]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "First Name is required")]
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string? Lastname { get; set; }
        [Required(ErrorMessage = "Mobile is required")]
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Pan Card is required")]
        public string? Pancard { get; set; }
        [Required(ErrorMessage = "Pin Code is required")]
        public string? Pincode { get; set; }
        [Required(ErrorMessage = "Required Amount is required")]
        public decimal Amount { get; set; }
    }
}
