using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectContactAPI.Models;
using ProjectContactAPI.Repositories.EF;
using ProjectContactAPI.Repositories.Interfaces;

namespace ProjectContactAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connection = Configuration["ConnectionString"];
            services.AddDbContext<ManagingContext>
                (options => options.UseSqlServer(connection));

            services.AddScoped<IProjectRepository, ProjectRepositoryEF>();
            services.AddScoped<IContactRepository, ContactRepositoryEF>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ManagingContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            ctx.Database.EnsureCreated();

            app.UseMvc();
        }
    }
}
