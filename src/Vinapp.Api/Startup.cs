using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Vinapp.Api.Services;
using Vinapp.Data;
using Vinapp.Data.Dal;
using Vinapp.Data.Models;

namespace Vinapp.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _config = builder.Build();
        }

        readonly IConfigurationRoot _config;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddDbContext<VinappContext>(ServiceLifetime.Scoped).AddIdentity<User, IdentityRole>();

            // Add framework services.
            services.AddMvc();

            services.AddTransient<ILotteryTicketService, LotteryTicketService>();
            services.AddTransient<ILotteryTicketRepository, LotteryTicketRepository>();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info
                {
                    Title = "Vinapp.API",
                    Version = "v1",
                    Description = "Vinapp.API provides backend for Vinapp",
                    Contact = new Contact { Name = "Ivan & Njaal @Ciber.no"},
                    License = new License { Name = "MIT/X11", Url = "https://opensource.org/licenses/MIT" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Vinapp.Api.xml");
                config.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_config.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Vinapp API v1");
            });
        }
    }
}
