using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApi.Extensions;
using WebAPI.Core.Manager;
using WebAPI.Core.Manager.User;
using WebAPI.Core.Repository;

namespace WebAPI
{
    public class Startup
    {
        protected ICollection<Assembly> Assemblies => new List<Assembly>
            {typeof(IUserManager).Assembly};

        protected readonly IWebHostEnvironment HostingEnvironment;

        protected bool AddEnvironmentVariables => true;

        public Startup(IWebHostEnvironment env)
        {
            HostingEnvironment = env;

            BuildConfiguration();
        }

        public IConfiguration Configuration { get; set; }

        protected IList<string> SettingsFiles => new List<string> { "appsettings.json" };

        protected string BasePath => HostingEnvironment.ContentRootPath;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var origins = Configuration.GetSection("Cors").GetValue<string>("AllowedHosts").Replace(" ", "").Split(",");

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });          

            services.AddJwtBearerAuthentication(Configuration);
                


            Assemblies.ToList().ForEach(assemblies =>
            {
                Type[] types = assemblies.GetTypes();
                string[] excludeClasses = new string[] { "ChangeLogContext", "BaseRepository`1","BaseManager`1" };
                types.Where(t => excludeClasses.Contains(t.Name) != true).Where(type => type.GetTypeInfo().IsClass).ToList().ForEach(type =>
                {
                    Type interfaceType = type.GetInterface($"I{type.Name}");
                    if (interfaceType != null)
                    {
                        services.Add(new ServiceDescriptor(interfaceType, type, ServiceLifetime.Scoped));
                    }
                });
            });
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseManager<>), typeof(BaseManager<>));
            services.AddControllers(option => option.EnableEndpointRouting = false).AddNewtonsoftJson();
        }

        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(BasePath);

            foreach (var settingsFile in SettingsFiles) builder.AddJsonFile(settingsFile, true, true);

            if (AddEnvironmentVariables) builder.AddEnvironmentVariables();

            Configuration = builder.Build();
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
            app.UseAuthentication();           

            app.UseAuthorization();
            app.UseCors("CorsApi");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
