using Microsoft.OpenApi.Models;

namespace Back.Rest.Api.Configuration
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = "Back Rest Api",
                    Description = "Api Demo",

                    Contact = new OpenApiContact()
                    {
                        Name = "Ricardo Hernández López",
                        Email = "rherl23@gmail.com"
                    }
                });

            });
        }
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Back Rest V1");
                //#if DEBUG
                //#else
                //#endif
                // c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
            });
        }
    }
}
