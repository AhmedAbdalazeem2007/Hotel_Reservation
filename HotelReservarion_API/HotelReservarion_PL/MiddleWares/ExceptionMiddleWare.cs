using System.Text.Json;

namespace HotelReservarion_PL.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionMiddleWare> logger;
        private readonly IHostEnvironment hostEnvironment;

        public ExceptionMiddleWare(RequestDelegate requestDelegate, ILogger<ExceptionMiddleWare> logger,
            IHostEnvironment hostEnvironment)
        {
            this.requestDelegate = requestDelegate;
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext httpContent)
        {
            try
            {
                await requestDelegate.Invoke(httpContent);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                httpContent.Response.ContentType = "application/json";
                httpContent.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = hostEnvironment.IsDevelopment() ?
                    new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
            : new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(response, options);
                httpContent.Response.WriteAsync(json);
            }
        }
    }
}
