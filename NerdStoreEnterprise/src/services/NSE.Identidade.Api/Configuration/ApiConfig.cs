namespace NSE.Identidade.Api.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();

        app.UseIdenitityConfiguration();

        return app;
    }
}