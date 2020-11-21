using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TCRB.BLL;
using TCRB.DAL.DataWrapper;
using TCRB.DAL.Model.Appsetting;
using TCRB.WEB.Helpers;
using TCRB.WEB.ModelBinder;

namespace TCRB.WEB
{
    public class Startup
    {
        public ILoggerFactory _loggerFactory;
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IOptions<AppsittingModel> appsitting)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllersWithViews();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddLogging(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.None).AddFilter(nameof(System), LogLevel.Warning);
            });

            services.Configure<AppsittingModel>(_configuration.GetSection("AppSettings"));
            services.AddHttpContextAccessor();

            #region Data Service
            services.AddScoped<UserTestDataService>();
            services.AddScoped<IDataAccessWrapper, DataAccessWrapper>();
            #endregion

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Clear();
                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedUICultures = new List<CultureInfo> {
                    new CultureInfo("th-TH"),
                    new CultureInfo("en-GB"),
                };
                options.SupportedCultures = new List<CultureInfo> {
                    new CultureInfo("th-TH"),
                    new CultureInfo("en-GB"),
                };
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddMvc(options => options.ModelBinderProviders.Insert(0, new ModelBinderProvider(_loggerFactory)));
            services.AddScoped<CustomCookieAuthenticationEvents>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.IsEssential = true;
                options.SlidingExpiration = true;
                options.Cookie.Name = $".{_configuration.GetSection("AppSettings")["ProjectName"]}";
#if DEBUG
                options.Cookie.Name = $".{_configuration.GetSection("AppSettings")["ProjectName"]}.Dev";
#endif
                options.ExpireTimeSpan = TimeSpan.FromMinutes((Convert.ToInt16(_configuration.GetSection("AppSettings")["LoginTimeExpired"])));
                options.LoginPath = new PathString("/Login/Index");
                options.LogoutPath = new PathString("/Login/Logout");
                options.Cookie.Path = "/";
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.HttpOnly = true;
                options.EventsType = typeof(CustomCookieAuthenticationEvents);
            });

#if DEBUG
            services.AddMvc().AddControllersAsServices().AddRazorRuntimeCompilation().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
#endif
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseResponseCaching();
            app.UseRequestLocalization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            System.Web.HttpContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "default", pattern: "{controller=Login}/{action=Index}"));
        }
    }
}
