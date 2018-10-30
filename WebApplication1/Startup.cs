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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
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
            //services.AddDbContext<WebAPIDbContext>(x => x.UseInMemoryDatabase("AppDatabase"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IPersonRepository, PersonRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //using (var serviceScope = app.ApplicationServices.CreateScope())
                //{
                //    var dbContext = serviceScope.ServiceProvider.GetService<WebAPIDbContext>();
                //    AddSampaleData(dbContext);
                //}
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        //private void AddSampaleData(WebAPIDbContext dbContext)
        //{
        //    dbContext.Persons.Add(new Person() { Id=1, GivenName = "Peter", FamilyName = "Casey", Age = 61, Address = "LondonDerry" });
        //    dbContext.Persons.Add(new Person() { Id = 2, GivenName = "Liadh", FamilyName = "Riada", Age = 51, Address = "Dublin" });
        //    dbContext.Persons.Add(new Person() { Id = 3, GivenName = "Michael", FamilyName = "Higgins", Age = 77, Address = "Limerick" });
        //    dbContext.SaveChanges();
        //}
    }
}
