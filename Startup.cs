using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using NetCoreSwagger.DAL;
using Newtonsoft.Json;
using System.Text.Json;
using NetCoreSwagger.Infrastructure;

namespace NetCoreSwagger
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
            services.AddControllers().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddDbContext<BookStoreDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("BookStoreDb")));


            services.AddSwaggerGen(s => {
                s.SwaggerDoc("NetCoreSwagger", new OpenApiInfo {
                    Version = "1.0.0",
                    Title = ".Net Core Web Api With Swagger",
                    Description = ".Net Core Web Api With Swagger",
                    Contact = new OpenApiContact(){
                        Name = "Book Store API Support",
                        Email = "kadir@kadirkaragoz.com",
                        Url = new Uri("https://kadirkaragoz.com")
                    },
                    TermsOfService = new Uri("http://example.com/terms/")
                });
            });

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(s => 
            {
                s.SwaggerEndpoint("/swagger/NetCoreSwagger/swagger.json", "Net Core Web Api With Swagger");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
