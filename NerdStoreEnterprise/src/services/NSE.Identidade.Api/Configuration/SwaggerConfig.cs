using Microsoft.OpenApi.Models;

namespace NSE.Identidade.Api.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = " NerdStore Enterprise Identity API ",
                Description = " Esta API faz parte do curso ASP.NET Core Enterprise Applications. ",
                Contact = new OpenApiContact() { Name = "Luik Castro", Email = "castro.luik@hotmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
        }
        
        return app;
    }
}