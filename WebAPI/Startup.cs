using CTI.Asset.Management.Application.Contracts.Repositories;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.CreateSoftwareLicenseUseCase;
using CTI.Asset.Management.Domain.Shared;
using CTI.Asset.Management.Infrastructure;
using CTI.Asset.Management.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CTI.Asset.Management.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public IHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionStrings"];
            services.AddDbContext<ApplicationContext>(optionsAction => optionsAction.UseNpgsql(connectionString));

            services.AddTransient<IDomainEventService, DomainEventService>();
            services.AddTransient<ISoftwareLicenseRepository, SoftwareLicenseRepository>();
            services.AddTransient<ICreateSoftwareLicenseUseCase, CreateSoftwareLicenseUseCase>();

            services.AddSingleton(Configuration);
            //services.AddSingleton(HostingEnvironment);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CTI.Asset.Management", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CTI.Asset.Management v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/
        }
    }
}
