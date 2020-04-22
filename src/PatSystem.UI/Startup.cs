using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatSystem.Domain.Interfaces;
using PatSystem.Infra.Data;
using PatSystem.Infra.Repository;
using System.Collections.Generic;
using System.Globalization;

namespace PatSystem.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Config dos Servicos
        public void ConfigureServices(IServiceCollection services)
        {

            #region DbContex
            services.AddDbContext<PatSystemContext>(options =>
                   options.UseMySql(Configuration.GetConnectionString("DBempregoStringConnection")));
            #endregion

            #region Services
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc(options => {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ClienteRepository>();
            services.AddScoped<CurriculoRepository>();
            services.AddScoped<CursoSuperiorRepository>();
            services.AddScoped<CursoTecnicoRepository>();
            services.AddScoped<ExperienciaRepository>();
            services.AddScoped<IdiomaRepository>();
            #endregion


        }

        // Config Uses Apps
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region ConfigBR
            var ptBr = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ptBr),
                SupportedCultures = new List<CultureInfo> { ptBr },
                SupportedUICultures = new List<CultureInfo> { ptBr }
            };
            app.UseRequestLocalization(localizationOptions);
            #endregion

            #region ConfigDeveloper
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            #endregion

            #region AppUse
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion
        }
    }
}
