using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project_Demo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Demo_1
{
    public class Startup
    {
        public IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<AppDbContext>(
                a => a.UseSqlServer(_config.GetConnectionString("PlayerInfoDbConnection")));


            services.AddMvc();

            //services.AddSingleton<PlayerInfoInterface, PlayerPersonalInfo>();

            services.AddScoped<PlayerInfoInterface, SQLPlayerRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                developerExceptionPageOptions.SourceCodeLineCount = 10;
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }

            //app.UseMvcWithDefaultRoute();

            //Conventional Routing

            app.UseStaticFiles();

            app.UseMvc(Router =>
            {Router.MapRoute("default", "{Controller=Home}/{Action=PlayersList}");}
            );

            //Conventional Routing

        }

    }
}
