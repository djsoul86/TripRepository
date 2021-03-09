using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Viajeros.DA;
using Viajeros.Services;
using Viajes.Services;

namespace Viajeros
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<DB>(options => options.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IViajerosRepository, ViajerosRepository>();
            services.AddScoped<IViajerosService, ViajeroService>();

            services.AddScoped<IViajesRepository, ViajesRepository>();
            services.AddScoped<IViajesService, ViajesService>();

            services.AddScoped<IPaisesRepository, PaisesRepository>();
            services.AddScoped<IPaisesService, PaisesService>();

            services.AddScoped<IReservasRepository, ReservasRepository>();
            services.AddScoped<IReservasService, ReservasService>();
        }
    



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
