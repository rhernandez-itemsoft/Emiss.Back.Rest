using Back.Rest.Api.Configuration;
using Back.Rest.Data;
using ItemsoftMX.Base.Data.Repositories;
using ItemsoftMX.Base.Domain.Filters;
using ItemsoftMX.Base.Domain.IRepositories;
using ItemsoftMX.Base.Domain.RequestFilters;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Back.Rest.Api
{
    public class Startup
    {
        /// <summary>
        /// Property Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            CorsExtension.Add(services, Configuration);

            
            
            services.AddDbContext<MsSqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BackRest")));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //AuthorizationExtension.Add(services, Configuration);

            DependencyInjectionExtension.Add(services);

            // services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionHandler))).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Filters.Add(typeof(CustomExceptionHandler));
                options.EnableEndpointRouting = false;
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; } );

            SwaggerExtension.AddSwagger(services);

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">app builder interface</param>
        /// <param name="env">webhots envieronment interface</param>
        /// <param name="dBContext">db context - DI</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MsSqlContext dBContext)
        {
            dBContext.Database.SetConnectionString(Configuration.GetConnectionString("BackRest"));
            if (!dBContext.Database.CanConnect())
            {
                throw new Exception("ERROR BD: No se ha podido conectar a la BD o esta NO EXISTE");
            }

            //dBContext.Database.Migrate();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // global cors policy
            /* app.UseCors(x => x
                // .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());*/
            app.UseCors("AllowSpecified");
      
            SwaggerExtension.UseCustomSwagger(app);

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseMvc();

            app.UseStaticFiles();
        }
    }
}
