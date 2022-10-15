using Ekisa.Api.BotFetal.Configuration;
using Ekisa.Api.BotFetal.Interfaces;
using Ekisa.Api.BotFetal.Interfaces.Services;
using Ekisa.Api.BotFetal.Interfaces.Services.Common;
using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Respositories;
using Ekisa.Api.BotFetal.Services;
using Ekisa.Api.BotFetal.Services.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rollbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitacora.Api.Interfaces.Repositories;
using Bitacora.Api.Interfaces.Services;
using Bitacora.Api.Respositories;
using Bitacora.Api.Services;

namespace Ekisa.Api.BotFetal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddDbContext<EkisaAppContext>(options =>
                    options.UseSqlServer(
                        _configuration.GetConnectionString("EkisaApp"),
                        providerOptions => providerOptions.EnableRetryOnFailure()
                    ));
            services.AddSingleton<IErrorLoggingDependency, ErrorLoggingClient>();
            services.AddScoped<IChatBotCitaRepository, ChatBotCitaRepository>();
            services.AddScoped<IChatBotCitaService, ChatBotCitaService>();
            services.AddScoped<IBitacoraService, BitacoraService>();
            services.AddScoped<IBitacoraRepository, BitacoraRepository>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IEmpleadosRepository, EmpleadoRepository>();
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bitacora.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bitacora.Api v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notificationHub");
            });

            // Configuraci�n Rollbar
            //RollbarLocator.RollbarInstance.Configure(new RollbarConfig(_configuration.GetSection("RollbarConfiguration")["AccessToken"])
            //{
            //    Environment = _configuration.GetSection("RollbarConfiguration")["Environment"]
            //});
            //RollbarLocator.RollbarInstance.Info("Rollbar is configured properly.");
        }
    }
}
