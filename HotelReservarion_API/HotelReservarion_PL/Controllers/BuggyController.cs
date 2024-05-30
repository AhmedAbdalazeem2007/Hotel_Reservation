



namespace HotelReservarion_PL.Controllers
{ 
    public class BuggyController : BaseApiController
    {
        private readonly ReservationDB _reservationDB;

        public BuggyController(ReservationDB reservationDB)
        {
            _reservationDB = reservationDB;
        }
        [HttpGet("not found")]
        public ActionResult Gatnotfoundrequest()
        {
            var room = _reservationDB.Rooms.Find(100);
            if (room is null)
                return NotFound(new ApiResponse(400));
            return Ok(room);
        }
        [HttpGet("servererror")]
        public ActionResult Getservererror()
        {
            var room = _reservationDB.Rooms.Find(100);
            var p = room.ToString();
            return Ok(p);
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest{id}")]
        public ActionResult GetBadrequest(int id)
        {
            if (ModelState.IsValid)
            {

            }
            return Ok();
        }


    }
}
