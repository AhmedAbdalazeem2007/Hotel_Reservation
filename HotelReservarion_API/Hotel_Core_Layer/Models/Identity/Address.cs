
namespace Hotel_Core_Layer.Models.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        //[ForeignKey("User")]
        //public string UderId { get; set; }
        //public ApplicationUser User { get; set; }
    }
}
