using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAppEFCore.Data;
using DemoAppEFCore.Interfaces;
using DemoAppEFCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoAppEFCore
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string conString = _configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conString));
            services.AddTransient<IProductRepo, ProductRepo>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
        }
    }
}
