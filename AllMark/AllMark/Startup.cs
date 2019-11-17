using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using AllMark.DAL;
using AllMark.Repository;
using AllMark.Config;
using AllMark.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace AllMark
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration,
                       IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<MvcOptions>(options => options.EnableEndpointRouting = false);

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            services.AddOptions();
            services.AddSingleton<AppSessionFactory>();
            services.AddScoped(x => x.GetRequiredService<AppSessionFactory>()
                                     .OpenSession());
            services.Configure<DatabaseConfig>(_configuration.GetSection("Database"));
            services.Configure<EmailConfig>(_configuration.GetSection("Email"));
            services.Configure<NationalCatalogConfig>(_configuration.GetSection("NationalCatalog"));
            services.Configure<HonestSignConfig>(_configuration.GetSection("HonestSign"));
            services.AddKendo();
            if (_environment.IsDevelopment())
            {
                services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMiddleware<CloseSessionMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddRepositories();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(i => i.FullName.StartsWith("AllMark")).ToArray();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(i => !string.IsNullOrEmpty(i.Namespace) && (i.Namespace.EndsWith(".Helpers") || i.Namespace.EndsWith(".Services")))
                .AsImplementedInterfaces();
        }
    }
}
