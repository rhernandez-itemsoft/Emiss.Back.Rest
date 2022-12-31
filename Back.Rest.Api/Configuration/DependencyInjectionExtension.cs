namespace Back.Rest.Api.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static void Add(this IServiceCollection services)
        {
            //services.AddScoped<IQueueConfigurationManager, QueueConfigurationManager>();
            //services.AddScoped<IQueueConfigurationRepository, QueueConfigurationRepository>();

            services.AddAutoMapper(typeof(Startup));
        }
    }
}
