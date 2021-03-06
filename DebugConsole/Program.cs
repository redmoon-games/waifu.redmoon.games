﻿using System;
using TournamentLibrary.CustomPlayer;
using TournamentLibrary.CustomTeam;
using TournamentLibrary.Models;
using TournamentLibrary.Rewards;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ITeam firstTeam = new RemTeam("First Team");
            ITeam secondTeam = new RemTeam("Second Team");
            ITournament tournament = new VSTournament(firstTeam, secondTeam);

            IPlayer newPlayer1 = new RemPlayer("saha1506");
            IPlayer newPlayer2 = new RemPlayer("BIG BOSS");

            firstTeam.AddPlayer(newPlayer1);
            secondTeam.AddPlayer(newPlayer2);

            AddInstantMoney(newPlayer1, new BigNumber(1, 5));
            PurchaseUpdateFor(newPlayer1, 100);
            for (int i = 0; i < 10; i++)
                PressClick(newPlayer1);
            WaitFor(100f, newPlayer1);

            AddInstantMoney(newPlayer2, new BigNumber(1, 4));
            PurchaseUpdateFor(newPlayer2, 100);
            for (int i = 0; i < 100; i++)
                PressClick(newPlayer2);
            WaitFor(1000f, newPlayer1);

            Console.WriteLine(tournament);
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
            var upgradeToLvlUp = player.Upgrades.Bundle[0];

            for (int i = 0; i < count; i++)
            {
                if (player.CanPay(upgradeToLvlUp.Price))
                    player.BuyUgrade(upgradeToLvlUp);
                else
                    Console.WriteLine($"{ player.ProfileInfo.Name }: need mor money!");
            }
        }
    }
}
