







using Hotel_Core_Layer.Services;

namespace HotelReservarion_PL.Controllers
{

	public class AccountController : BaseApiController
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ITokenServices _tokenServices;
		private readonly IMapper _mapper;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
			ITokenServices tokenServices,
			IMapper mapper)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenServices = tokenServices;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register([FromForm]RegisterDto registerDto)
		{
			if (CheckEmailExist(registerDto.Email).Result.Value)
			{
				return BadRequest();
			}
			var user = new ApplicationUser()
			{ 
				F_Name = registerDto.F_Name,
				L_Name = registerDto.L_Name,
				Email = registerDto.Email,
				PhoneNumber = registerDto.PhoneNumber,
				UserName = registerDto.Email.Split('@')[0],
			Gender= registerDto.Gender

			};
			var l = _userManager.FindByEmailAsync(user.Email);
			if (l is not null)
				return null;
			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (!result.Succeeded)
			{
				return BadRequest();
			}
			return Ok(new UserDto()
			{
				DisplayName = user.F_Name + user.L_Name,
				Email = user.Email,
				Token =await _tokenServices.CreateTokenAsync(user, _userManager)
			}) ;
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user == null)
			{
				return Unauthorized();
			}
			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
			if (!result.Succeeded)
			{
				return Unauthorized();
			}
			return Ok(new UserDto()
			{
				DisplayName = user.UserName,
				Email = user.Email,
				Token = await _tokenServices.CreateTokenAsync(user, _userManager)
			});
		}
		

		[HttpGet("emailexist")]
		public async Task<ActionResult<bool>> CheckEmailExist(string email)
		{
			return await _userManager.FindByEmailAsync(email) is not null;
		}
	}
}
