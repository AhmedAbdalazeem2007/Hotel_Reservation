namespace HotelReservarion_PL.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public ApiResponse()
        {

        }
        public ApiResponse(int status, string? message = null)
        {

            StatusCode = status;
            Message = message ?? GetDefaulMessageforStatusCode(status);
        }
        public string GetDefaulMessageforStatusCode(int status)
        {
            return status switch
            {
                400 => "Bad Request",
                401 => "UnAuthorized",
                _ => null
            };
        }

    }
}
