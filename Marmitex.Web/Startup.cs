﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marmitex.DI;
using Marmitex.Domain.Entidades;
using Marmitex.Domain.Interfaces;
using Marmitex.Web.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marmitex.Web
{
    public class Startup
    {

        // public Startup(IHostingEnvironment env)
        // {
        //     var builder = new ConfigurationBuilder()
        //         .SetBasePath(env.ContentRootPath)
        //         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //         .AddEnvironmentVariables();
        //     Configuration = builder.Build();
        // }

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            Init.ConfigureServices(services, Configuration.GetConnectionString("DefaultConnection"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            //
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //save database
            app.Use
            (async (context, next) =>
               {
                   //Request
                   await next.Invoke();
                   //Response
                   var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));

                   var removeMistura = (IRepositoryBase<Mistura>)context.RequestServices.GetService(typeof(IRepositoryBase<Mistura>));
                   var removeSalada = (IRepositoryBase<Salada>)context.RequestServices.GetService(typeof(IRepositoryBase<Salada>));
                   var removeAcompanhamento = (IRepositoryBase<Acompanhamento>)context.RequestServices.GetService(typeof(IRepositoryBase<Acompanhamento>));

                   await removeAcompanhamento.RemoveProdutoAntigo<Acompanhamento>();
                   await removeSalada.RemoveProdutoAntigo<Salada>();
                   await removeMistura.RemoveProdutoAntigo<Mistura>();
                   await unitOfWork.Commit();


               }
            );


            // end save

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Cliente}/{action=Index}/{id?}");
            });
        }
    }
}
