

namespace HotelReservarion_PL.Controllers
{

    public class ReservationController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ReservationController(IUnitOfWork unitOfWork,IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task< ActionResult> CreateReservation([FromForm]ReservationBookDto reservationBookDto)
        {
            if (reservationBookDto == null)
            {
                return BadRequest();
            }
            bool isfound = false;
            var booking = mapper.Map<ReservationBookDto, Booking>(reservationBookDto);
            foreach(var p in await _unitOfWork.Repository<Booking>().GetAllAsync())
            {
                decimal price = 0;
               if(p.Email==reservationBookDto.Email)
                {
                    isfound = true;
                    booking.TotalCost -= reservationBookDto.TotalCost * .05m;
                    break;
                }
            }
            if (!isfound)
            {
                var user = await userManager.FindByEmailAsync(reservationBookDto.Email);
                user.IsAlreadyBooked = true;
                await userManager.UpdateAsync(user);
            }
            _unitOfWork.Repository<Booking>().Add(booking);
            return Ok(booking);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var booking = _unitOfWork.Repository<Booking>().GetByIdAsync(id.Value);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }
        [HttpPut("update")]
        public async Task<ActionResult> EditBook(ReservationBookDto reservationBookDto)
        {
            var book = mapper.Map<ReservationBookDto, Booking>(reservationBookDto);
            _unitOfWork.Repository<Booking>().Update(book);
            return Ok();
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteBook(ReservationBookDto reservationBookDto)
        {
            var book = mapper.Map<ReservationBookDto, Booking>(reservationBookDto);
            _unitOfWork.Repository<Booking>().Delete(book);
            return Ok();
        }

    }
}
