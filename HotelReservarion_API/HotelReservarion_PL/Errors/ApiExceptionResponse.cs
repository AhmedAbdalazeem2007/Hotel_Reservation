namespace HotelReservarion_PL.Errors
{
    public class ApiExceptionResponse:ApiResponse
    {
        public string? Details {  get; set; }
        public ApiExceptionResponse(int statuscode, string? message=null, string? detiails=null) : base(statuscode, message)
        {
            Details = detiails;
        }
    }
}
