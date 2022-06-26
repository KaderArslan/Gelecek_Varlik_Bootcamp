using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workfollow.Bll;
using Workfollow.Dal.Abstract;
using Workfollow.Dal.Concrete.Entityframework.Context;
using Workfollow.Dal.Concrete.Entityframework.Repository;
using Workfollow.Dal.Concrete.Entityframework.UnitOfWork;
using Workfollow.Interface;

namespace Workfollow.WebApi
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
            #region JwtTokenService
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;

                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        //validate doðrulama
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        RequireSignedTokens = true, //token zorunlu mu
                        RequireExpirationTime = true
                    };
                }
                );
            #endregion

            #region ApplicationContext
            //services Collection servicesdir, servise yukledigimiz ifadeleri bir cok yerde kullanabiliyoruz 
            services.AddDbContext<WORKContext>();
            //eslestirme kisimlari Scoped le oluyor
            services.AddScoped<DbContext, WORKContext>();//Dbcontext WORKContext'ten kendini turet
            //Dal katmaninda ayar yapmadan 10 tane bile context kullanabiliriz
            //context belirtmenin en sade yontemi budur



            //Furkanýn Yontemi bunda ise optionBuilder'i yine yorum satiri yaparim iflerle birlikte
            //ve WORKContexteki 2 constructor acilir ve asagidaki 
            // ve services.AddDbContext<WORKContext>(); yukaridaki kismida kapatiriz

            //services.AddDbContext<WORKContext>
            //    (
            //    ob => ob.UseSqlServer(Configuration.GetConnectionString(".SqlServer"))
            //    );

            #endregion

            // generic'i tek basina nasil kullanabiliriz
            // employe reposu yazmadan employein tum ozelligini kullanmak gibi, employe icin ekleme silme kaydetme yapmak icin

            #region ServiceSection
            //IEmployeeService cagirildiginda EmployeeManager dan kendini turet
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IRequestService, RequestManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IJobListService, JobListManager>();
            //diger serviceslerde buraya yazilir
            #endregion

            #region RepositorySection
            //genericte burada yazilir
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IJobListRepository, JobListRepository>();
            #endregion

            #region UnitOfWork
            //UnitOfWork aktif etmezsek yoksa kaydetme silme islemleri olmaz listeleme olur unitofWork
            services.AddScoped<IUnitofWork, UnitOfWork>();
            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Workfollow.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workfollow.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
