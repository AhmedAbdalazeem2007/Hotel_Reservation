


namespace Hotel_Core_Layer.Models.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public int Id {  get; set; }
		public string F_Name { get; set; }
		public string L_Name { get; set; }
		public string NationalId { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public bool Gender { get; set; }
		public bool IsAlreadyBooked { get; set; } = false;
		//[ForeignKey("Address")]
		//public int AddressId { get; set; }
		//public Address Address { get; set; }
		public ApplicationUser()
        {
            
        }

    }
}
