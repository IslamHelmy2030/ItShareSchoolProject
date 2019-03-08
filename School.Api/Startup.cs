using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using School.DataLayer.Context;
using School.DataLayer.Entities;
using School.Domain;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Repositories.Repository;
using School.Repositories.UnitOfWork;
using Swashbuckle.AspNetCore.Swagger;

namespace School.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(cfg => { cfg.UseSqlServer(_configuration.GetConnectionString("SchoolConnection")); });

            services.AddAutoMapper();

            services.AddScoped<DbContext, SchoolContext>();

            services.AddTransient<IGenderBusiness, GenderBusiness>();
            services.AddTransient<IUnitOfWork<Gender>, UnitOfWork<Gender>>();
            services.AddTransient<IRepository<Gender>, Repository<Gender>>();

            services.AddTransient<ILevelBusiness, LevelBusiness>();
            services.AddTransient<IUnitOfWork<Level>, UnitOfWork<Level>>();
            services.AddTransient<IRepository<Level>, Repository<Level>>();


            services.AddTransient<ITeacherBusiness, TeacherBusiness>();
            services.AddTransient<IUnitOfWork<Teacher>, UnitOfWork<Teacher>>();
            services.AddTransient<IRepository<Teacher>, Repository<Teacher>>();


            services.AddTransient<IStudentBusiness, StudentBusiness>();
            services.AddTransient<IUnitOfWork<Student>, UnitOfWork<Student>>();
            services.AddTransient<IRepository<Student>, Repository<Student>>();





            services.AddSwaggerGen(cfg => cfg.SwaggerDoc("v1", new Info { Title = "School API", Version = "v1" }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(cfg => cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "School API V1"));
        }
    }
}
