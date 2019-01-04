using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PeykOn.Data;
using PeykOn.Services;

namespace PeykOn
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedRedisCache(options => { options.Configuration = "localhost"; });

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddDbContext<PeykOnDbContext>(options => options
                .UseNpgsql(_configuration["ConnectionString"], builder => builder
                    .MigrationsAssembly(typeof(Startup).Assembly.FullName)
                    .MigrationsHistoryTable("ef_migrations_history")
                ));

            services.AddScoped<IRegistrationService, RegistrationService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}