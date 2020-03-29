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
using ParkingAppAPI.Data;
using ParkingAppAPI.Data.Repositories;
using ParkingAppAPI.Models;

namespace ParkingAppAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<ParkingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ParkingContext")));
            services.AddScoped<IParkingRepository, ParkingRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddSwaggerDocument();
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwaggerUi3();
            app.UseSwagger();
            app.UseRouting();
            
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();

            });
        }
    }
}
