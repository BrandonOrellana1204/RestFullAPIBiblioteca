using Aplicacion.Wrappers;
using Azure;
using System.Net;
using System.Text.Json;

namespace ApiWeb.Intermedio
{
    public class ManejadorErrores
    {
        private readonly RequestDelegate _next;

        public ManejadorErrores(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Respuesta<string>() { Confirmar=false,Mensaje = error?.Message};
                switch (error)
                {
                    case Aplicacion.Exceptions.ApiExcepciones e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Aplicacion.Exceptions.ExcepcionesValidacion e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Error;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var resultado = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(resultado);
            }
         
        }
    }
}
