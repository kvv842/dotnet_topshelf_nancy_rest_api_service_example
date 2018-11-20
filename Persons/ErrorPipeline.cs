using Nancy;
using Nancy.Bootstrapper;
using Newtonsoft.Json;
using Persons.Exceptions;
using System.Text;

namespace Persons
{
    public class ErrorPipeline : IApplicationStartup
    {
        private const string ContentTypeResult = "application/json";

        public void Initialize(IPipelines pipelines)
        {
            pipelines.OnError += (context, exception) =>
            {
                if (exception is BadRequestException)
                {
                    return CreateErrorResponse(HttpStatusCode.BadRequest, exception.Message);
                };

                if (exception is UnprocessableEntity)
                {
                    return CreateErrorResponse(HttpStatusCode.UnprocessableEntity, exception.Message);
                };

                if (exception is NotFound)
                {
                    return CreateErrorResponse(HttpStatusCode.NotFound, exception.Message);
                };

                return HttpStatusCode.InternalServerError;
            };
            
        }

        private Response CreateErrorResponse(HttpStatusCode httpStatusCode, string message)
        {
            return new Response
            {
                StatusCode = httpStatusCode,
                ContentType = ContentTypeResult,
                Contents = (stream) =>
                {
                    var errorDto = new ErrorDto { Message = message };
                    var jsonError = JsonConvert.SerializeObject(errorDto);
                    var errorMessage = Encoding.UTF8.GetBytes(jsonError);
                    stream.Write(errorMessage, 0, errorMessage.Length);
                }
            };
        }

        private class ErrorDto
        {
            public string Message { get; set; }
        }

    }

    
}
