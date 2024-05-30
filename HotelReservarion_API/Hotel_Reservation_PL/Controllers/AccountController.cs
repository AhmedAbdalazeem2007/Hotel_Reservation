
namespace Hotel_Reservation_PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    F_Name = registerViewModel.F_Name,
                    L_Name = registerViewModel.L_Name,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Email = registerViewModel.Email,
                    Gender = registerViewModel.Gender,
                    NationalId = registerViewModel.NationalId,
                    UserName = registerViewModel.Email.Split('@')[0],
                };
                var user_1 = userManager.FindByEmailAsync(user.Email);
                if (user_1 is not null)
                    return null;
                else
                {
                    var result = await userManager.CreateAsync(user, registerViewModel.Password);
                    return RedirectToAction("Index", "Booking");
                }
            }
            return View(registerViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Booking");
            }
            return View(loginViewModel);
        }
    }
}
