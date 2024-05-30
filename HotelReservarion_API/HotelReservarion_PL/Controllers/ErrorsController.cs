

namespace HotelReservarion_PL.Controllers
{
    [Route("error/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ErrorsController()
        {

        }
        [HttpGet]
        public ActionResult Error(int code)
        {
            return NotFound(new ApiResponse(code));
        }
    }
}
