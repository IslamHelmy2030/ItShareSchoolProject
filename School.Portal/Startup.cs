using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.DataLayer.Context;
using School.DataLayer.Entities;
using School.Domain;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Repositories.Repository;
using School.Repositories.UnitOfWork;

namespace School.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(cfg => { cfg.UseSqlServer(_configuration.GetConnectionString("SchoolConnection")); });
            services.AddAutoMapper();

            services.AddScoped<DbContext, SchoolContext>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
