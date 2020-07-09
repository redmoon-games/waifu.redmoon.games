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
using TournamentLibrary.Player;
using TournamentLibrary.Rewards;
using TournamentLibrary.Team;
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

            ITeam firstTeam = new RemTeam("First Team");
            ITeam secondTeam = new RemTeam("SEcond Team");

            services.AddSingleton<ITournament>(x => new VSTournament(firstTeam, secondTeam));
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
                ITeam firstTeam = new RemTeam("First Team");
                ITeam secondTeam = new RemTeam("Second Team");
                ITournament tournament = new VSTournament(firstTeam, secondTeam);

                IPlayer newPlayer1 = new WebPlayer("saha1506");
                IPlayer newPlayer2 = new WebPlayer("BIG BOSS");

                firstTeam.AddPlayer(newPlayer1);
                secondTeam.AddPlayer(newPlayer2);

                AddInstantMoney(newPlayer1, new BigNumber(1, 5));
                PurchaseUpdateFor(newPlayer1, 100);
                for (int i = 0; i < 100; i++)
                    PressClick(newPlayer1);
                WaitFor(100f, newPlayer1);

                AddInstantMoney(newPlayer2, new BigNumber(1, 4));
                PurchaseUpdateFor(newPlayer2, 100);
                for (int i = 0; i < 1000; i++)
                    PressClick(newPlayer2);
                WaitFor(1000f, newPlayer1);

                Console.WriteLine(tournament);
                await next.Invoke();
            });
        }
        private static void WaitFor(float seconds, IPlayer player)
        {
            player.AddReward(new TimeReward(player.Upgrades, seconds));
        }

        private static void AddInstantMoney(IPlayer newPlayer, BigNumber money)
        {
            newPlayer.AddReward(new InstantMoneyReward(money));
        }
        private static void PressClick(IPlayer newPlayer)
        {
            var reward = new ClickReward(newPlayer.Upgrades.MoneyPerClick);
            newPlayer.AddReward(reward);
        }
        private static void PurchaseUpdateFor(IPlayer player, int count)
        {
            var upgradeToLvlUp = player.Upgrades.Upgrades[0];

            for (int i = 0; i < count; i++)
            {
                if (player.CanPay(upgradeToLvlUp.Price))
                    player.BuyUgrade(upgradeToLvlUp);
                else
                    Console.WriteLine($"{ player.ProfileInfo.Login }: need mor money!");
            }
        }
    }
}
