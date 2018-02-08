﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyPhotos.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyPhotos
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //mindig újat példányosít minden kontrollerben
            //services.AddTransient<PhotoRepository, PhotoRepository>();

            //Azért, hogy minden egyes kérésnél ugyanahhoz a repositoryhoz jussunk, Singleton-ként kell regisztrálnunk.
            //A C# Singleton mintáról részletesen: http://csharpindepth.com/articles/general/singleton.aspx       
            services.AddSingleton<PhotoRepository, PhotoRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvcWithDefaultRoute();
        }
    }
}