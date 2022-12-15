using Foodie.Repositories.Interfaces;
using Foodie.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Foodie.Services.Interfaces;
using Foodie.Services;
using Foodie.Helper;

namespace Foodie
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            services.TryAddScoped<IRestaurantService, RestaurantService>();
 
            services.TryAddScoped<IRatingService, RatingService>();

            services.TryAddScoped<IDishService, DishService>();

            services.AddTransient<CustomExceptionHandler>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
