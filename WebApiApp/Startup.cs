using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using AutoMapper;
using WebApp24I.AppCore.Interfaces;
using WebApp24I.AppCore.Models;
using WebApp24I.Infrastructure.Services;

namespace WebApp24I.WebApiApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MessageBrokerSettings>(Configuration.GetSection("MessageBroker"));
            services.AddSingleton<IMessageProducer, MessageProducer>(sp =>
            {
                var settings = sp.GetService<IOptions<MessageBrokerSettings>>().Value;

                return new MessageProducer(settings);
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
