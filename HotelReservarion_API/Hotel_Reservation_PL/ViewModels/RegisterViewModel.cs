using System.ComponentModel.DataAnnotations;

namespace Hotel_Reservation_PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string F_Name { get; set; }
        [Required]
        public string L_Name { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [RegularExpression("")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
    }
}
