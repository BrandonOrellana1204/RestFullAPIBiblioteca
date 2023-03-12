using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Extenciones
{
    public static class ServiciosExtension
    {
        public static void AgregarApiExtencion(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1,0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

        }
    }
}
