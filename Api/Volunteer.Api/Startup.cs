﻿namespace Volunteer.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using TempDAL;
    using Activities.Interactor;
    using BLModels.Entities;
    using Comments.DataManager;
    using Comments.Entity;
    using Comments.Manager;
    using DirtyData;
    using MainModule.Managers;
    using MainModule.Managers.DataManagers;
    using MainModule.Managers.Implementations;
    using MainModule.Services.Interfaces;
    using MainModule.Services.Implementations;
    using Volunteer.MainModule.Automapper;
    using AutoMapper;
    using System.Collections.Generic;
    using Api.Automapper;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "My API", Version = "v1" });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IDataManager<Activity>, ActivityDataManager>();
            services.AddTransient<ISimpleManager<Activity>, ActivityManager>();
            services.AddTransient<IDataManager<Comment>, CommentDataManager>();
            services.AddTransient<ISimpleManager<Comment>, CommentsManager>();
            services.AddTransient<ActivitiesInteractor>();
            services.AddTransient<ISimpleManager<User>, UserManager>();
            services.AddTransient<IDataManager<User>, UserDataManager>();
            services.AddTransient<IUserService, UserService>();
           

            List<Profile> automapperProfiles = new List<Profile>();
            automapperProfiles.Add(AutomapperConfig.GetAutomapperProfile());
            automapperProfiles.Add(new ViewModelsMapperProfile());
            var mappingConfig = new MapperConfiguration(mc =>
            {
                foreach (var item in automapperProfiles)
                {
                    mc.AddProfile(item);
                }
                mc.AllowNullCollections = true;
                mc.AllowNullDestinationValues = true;
                mc.EnableNullPropagationForQueryMapping = true;
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            TempDataInitializer.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseOptions();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
