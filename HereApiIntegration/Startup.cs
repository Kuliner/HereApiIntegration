﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HereApiIntegration.Definitions.Extensions;
using Microsoft.OpenApi.Models;
using HereApiIntegration.Definitions.Options;
using HereApiIntegration.Definitions;
using Serilog;

namespace HereApiIntegration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HereAPI integration", Version = "v1" });
            });

            services.RegisterRepositories();
            services.RegisterServices();

            services.AddHttpClient();
            services.AddOptions();

            services.Configure<JsonRepositoryPath>(Configuration.GetSection(Consts.FakeDataPath));
            services.Configure<HereAPICredentials>(Configuration.GetSection(Consts.HereAPICredentials));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
