using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Config.Demo
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

            //One way of do it
            var version = Configuration.GetValue<string>("Version");
            var db = Configuration["Settings:Database"];

            services.AddSingleton(db);
            services.AddSingleton(version);

            //Another way
            var custom = new Custom();
            Configuration.GetSection("Custom").Bind(custom);

            //Another way
            services.Configure<Custom>(Configuration.GetSection("Custom"));
            services.AddSingleton(custom);

            Console.WriteLine(version);
            Console.WriteLine(db);

            Console.WriteLine(Configuration["TEST_ENV"]);
            Console.WriteLine(Configuration["CustomConfig"]);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
