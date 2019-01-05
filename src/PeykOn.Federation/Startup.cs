using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PeykOn.Federation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
//            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
//            else
            {
//                app.UseHsts();
            }

//            app.UseHttpsRedirection();
            app.UseDefaultFiles().UseStaticFiles();
            app.UseMvc();
        }
    }
}