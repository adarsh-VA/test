using Foodie.Repositories.Interfaces;
using Foodie.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Foodie.Services.Interfaces;
using Foodie.Services;
using Foodie.Helper;

namespace Foodie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Foodie", Version = "v1" });
            });
            
            services.TryAddScoped<IRestaurantService, RestaurantService>();
            services.TryAddScoped<IRestaurantRepository, RestaurantRepository>();
            services.TryAddScoped<IDbHelper, DbHelper>();
            services.AddTransient<CustomExceptionHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foodie v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<CustomExceptionHandler>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
