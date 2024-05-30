
namespace Hotel_Core_Layer.Services
{
	public interface ITokenServices
	{
		Task<string> CreateTokenAsync(ApplicationUser applicationUser, UserManager<ApplicationUser> userManager);
	}
}
