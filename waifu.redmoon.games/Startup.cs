using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TournamentLibrary.Models;
using waifu.redmoon.games.Data;

namespace waifu.redmoon.games
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } //NLog, Serilog, log4net

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            ITeam Rem = new SummerTeam("���");
            ITeam Zui = new SummerTeam(Configuration.GetSection("TeamA").Get<TeamSettings>().Name);
            //services.AddTransient<ITeam>(x => new SummerTeam(Guid.NewGuid().ToString()));
            services.AddSingleton<ITournament>(x => new VSTournament(Zui, Rem));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITournament trt)
        {
            StartCompetition(app, trt);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private static void StartCompetition(IApplicationBuilder app, ITournament trt)
        {
            app.Use(async (context, next) =>
            {
                ITournament tournament = app.ApplicationServices.GetRequiredService<ITournament>();
                ITeam Asui = new SummerTeam("����");
                ITeam Rem = new SummerTeam("����");
                ITournament tournament1 = app.ApplicationServices.GetRequiredService<ITournament>();
                IPlayer newPlayer = new Player("saha1506");
                IPlayer newPlayer2 = new Player("ZaBiAVaKa");
                tournament.AddPlayer(newPlayer, Asui);
                tournament1.AddPlayer(newPlayer2, Rem);
                await next.Invoke();
            });
        }
    }
}
