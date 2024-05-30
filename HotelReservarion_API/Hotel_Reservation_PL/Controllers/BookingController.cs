using Microsoft.AspNetCore.Mvc;
using Hotel_Reservation_DAL.Models;
using AutoMapper;
using Hotel_Reservation_PL.ViewModels;
using Hotel_Reservation_BLL.Repositories;
using Hotel_Reservation_BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Hotel_Reservation_DAL.Models.Identity;


namespace Hotel_Reservation_PL.Controllers
{
    public class BookingController : Controller
    {
        private readonly IGenericRepository<Booking> genericRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
      
        public BookingController( IGenericRepository <Booking> genericRepository,IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var books = await genericRepository.GetAllAsync();
            var Booingmapping = mapper.Map<IReadOnlyList<Booking>, IReadOnlyList<BookViewModel>>(books);
            return View(Booingmapping);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isfound = false;

                foreach (var p in await genericRepository.GetAllAsync())
                {
                    decimal price = 0;
                    if (p.Email == bookViewModel.Email)
                    {
                        isfound = true;
                        bookViewModel.TotalCost -= bookViewModel.TotalCost * .05m;
                        break;
                    }
                }
                if (!isfound)
                {
                    var user = await userManager.FindByEmailAsync(bookViewModel.Email);
                    user.IsAleaderyreserved = true;
                    await userManager.UpdateAsync(user);
                }
                var book = mapper.Map<BookViewModel, Booking>(bookViewModel);
                await genericRepository.Add(book);
            }
            return View(bookViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var booking = await genericRepository.GetByIdAsync(id.Value);
            if (booking == null)
                return NotFound();
            var book = mapper.Map<Booking, BookViewModel>(booking);
            return View(book);
            
        }
        [HttpPost]
        public async Task<IActionResult> Details(BookViewModel bookViewModel)
        {
            return View(bookViewModel);
        }


    }
}
