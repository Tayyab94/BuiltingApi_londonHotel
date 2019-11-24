﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using London_Api_corePractice.Filters;
using London_Api_corePractice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace London_Api_corePractice
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

            services.Configure<HotelInfo>(Configuration.GetSection("Info"));

            //use In-Memory data Base for Quick Developing 

            //TODO swap for real database.. latter..
            services.AddDbContext<HotelAPIDbContext>(options =>
            {
                options.UseInMemoryDatabase("londondb");
            });


            services.AddMvc(options=> {
                options.Filters.Add<JsonExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting(option =>
            {
                option.LowercaseUrls = true;
            });

            services.AddSwaggerDocument();

            #region  set Api Verson here
            // Below line of Code is showing how we can set the default version of APi
            
            services.AddApiVersioning(options =>
            {

                options.DefaultApiVersion = new ApiVersion(1, 0);

                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            #endregion


            #region Secure APIs
            services.AddCors(options =>
            {
                options.AddPolicy("AllowUSers", policy =>
                {
                    policy.AllowAnyOrigin();

                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
                app.UseSwaggerUi3();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();

            app.UseCors("AllowUSers");
            app.UseMvc();
        }
    }
}
