namespace Back.Rest.Api.Configuration
{
    public static class CorsExtension
    {

        public static void Add(this IServiceCollection services, IConfiguration _configuration)
        {
            string _allowedHostStr = _configuration.GetValue<string>("AllowOrigin");
            string[] allowedHost = _allowedHostStr.Split(",");

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecified", options =>
                options
                   .AllowAnyMethod()
                   .AllowCredentials()
                   .AllowAnyHeader()
                   .AllowAnyOrigin()
                   .WithExposedHeaders("Access-Control-Allow-Origin", "Access-Control-Allow-Headers", "*")
                   .WithOrigins(allowedHost)
                   .SetIsOriginAllowed(isOriginAllowed: _ => true)
               );
            });
        }
    }
}
