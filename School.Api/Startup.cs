using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using School.DataLayer.Context;
using School.DataLayer.Entities;
using School.Domain;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Repositories.Repository;
using School.Repositories.UnitOfWork;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            services.AddDbContext<SchoolContext>(cfg =>
                {
                    cfg.UseSqlServer(_configuration.GetConnectionString("SchoolConnection"));
                    //.UseLazyLoadingProxies();
                }).AddIdentity<IdentityUser, IdentityRole>(option =>
                {
                    option.Password.RequireDigit = false;
                    option.Password.RequiredLength = 6;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                    option.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<SchoolContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "www.Yahoo.com",
                    ValidateAudience = true,
                    ValidAudience = "www.google.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SaraAmroMohammedMoamen")),
                };
            });
            
            services.AddAutoMapper();

            services.AddScoped<DbContext, SchoolContext>();
            services.AddTransient<IAccountBusiness, AccountBusiness>();
            services.AddTransient<IGenderBusiness, GenderBusiness>();
            services.AddTransient<IUnitOfWork<Gender>, UnitOfWork<Gender>>();
            services.AddTransient<IRepository<Gender>, Repository<Gender>>();

            services.AddTransient<ILevelBusiness, LevelBusiness>();
            services.AddTransient<IUnitOfWork<Level>, UnitOfWork<Level>>();
            services.AddTransient<IRepository<Level>, Repository<Level>>();

            services.AddTransient<ISubjectBusiness, SubjectBusiness>();
            services.AddTransient<IUnitOfWork<Subject>, UnitOfWork<Subject>>();
            services.AddTransient<IRepository<Subject>, Repository<Subject>>();

            services.AddTransient<IClassRoomBusiness, ClassRoomBusiness>();
            services.AddTransient<IUnitOfWork<ClassRoom>, UnitOfWork<ClassRoom>>();
            services.AddTransient<IRepository<ClassRoom>, Repository<ClassRoom>>();
            services.AddTransient<ITeacherBusiness, TeacherBusiness>();
            services.AddTransient<IUnitOfWork<Teacher>, UnitOfWork<Teacher>>();
            services.AddTransient<IRepository<Teacher>, Repository<Teacher>>();


            services.AddTransient<IStudentBusiness, StudentBusiness>();
            services.AddTransient<IUnitOfWork<Student>, UnitOfWork<Student>>();
            services.AddTransient<IRepository<Student>, Repository<Student>>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "School API V1", Version = "v1" });

                options.DescribeAllEnumsAsStrings();
                var filePath = Path.Combine(AppContext.BaseDirectory, "School.Api.xml");
                options.IncludeXmlComments(filePath);

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                options.AddSecurityRequirement(security);

            });

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(
                options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            );

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "School API V1");
                c.DocumentTitle = "ERP Documentation";
                c.DocExpansion(DocExpansion.None);
            });
            app.UseMvc();

            dbContext.Database.EnsureCreated();
        }
    }
}
