using ApiWeb.Intermedio;

namespace ApiWeb.Extenciones
{
    public static class AppExtencion
    {
      public static void UsarMediadorErrores(this IApplicationBuilder app)
        {
            app.UseMiddleware<ManejadorErrores>();
        }
    }
}
