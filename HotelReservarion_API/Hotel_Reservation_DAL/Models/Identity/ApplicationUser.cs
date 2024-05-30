

namespace Hotel_Reservation_DAL.Models.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAleaderyreserved {  get; set; }
        public bool Gender { get; set; }
    }
}
