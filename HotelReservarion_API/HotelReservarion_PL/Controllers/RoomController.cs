




namespace HotelReservarion_PL.Controllers
{
	public class RoomController : BaseApiController
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public RoomController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<RoomDto>>> GetAll()
		{
			var spec = new RoomWithHoteAndFloorSpecification();
			var rooms = await _unitOfWork.Repository<Room>().GetAllAsync();
			if (rooms == null) return NotFound();
			var data = _mapper.Map<IReadOnlyList<Room>, IReadOnlyList<RoomDto>>(rooms);
			return Ok(data);
		}

	
		[HttpPost]
		public async Task<ActionResult> AddRoom(RoomDto roomDto)
		{
			var room = _mapper.Map<RoomDto, Room>(roomDto);
			await _unitOfWork.Repository<Room>().Add(room);
			return Ok();
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteRoom(int? id)
		{
			if (id == null)
				return BadRequest();
			var spec = new RoomWithHoteAndFloorSpecification(id.Value);
			var room = await _unitOfWork.Repository<Room>().GetByIdAsync(id.Value);
			if (room == null)
				return NotFound(new ApiResponse(404));
			_unitOfWork.Repository<Room>().Delete(room);
			return Ok();
		}
		[HttpGet("{id}")]
        [ProducesResponseType(typeof(RoomDto), 200)]
        public async Task<ActionResult<RoomDto>> Details(int? id)
		{
            if (id == null)
                return BadRequest();
            var spec = new RoomWithHoteAndFloorSpecification(id.Value);
            var room = await _unitOfWork.Repository<Room>().GetByIdAsync(id.Value);
            if (room == null)
                return NotFound(new ApiResponse(404));
            var _room = _mapper.Map<Room, RoomDto>(room);
            return Ok(_room);
        }
    }
}
