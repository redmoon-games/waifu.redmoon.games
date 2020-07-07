using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public abstract class UpgradesBundle : IUpgradesBundle
    {
        protected Dictionary<int, int> CurrentUpgradesLvl_By_ID { get; }

        public BigNumber MoneyPerClick
        {
            get { return new BigNumber(); }
        }

        public BigNumber MoneyPerSec
        {
            get { return new BigNumber(); }
        }

        private readonly UpgradeModel[] _upgradesTemplate;

        public UpgradesBundle(UpgradeModel[] upgrades)
        {
            _upgradesTemplate = upgrades;
            CurrentUpgradesLvl_By_ID = CreateUpgradeDictionary(upgrades);
        }

        public BigNumber GetUpgradePrice(int upgradeId)
        {
            if (IdIsExist(upgradeId))
                return _upgradesTemplate[upgradeId].UpgradePrice;
            throw new NullReferenceException("Id is not correct!");
        }
        public void AddLvlToUpgrade(int updateId, int numberOfUpgrades = 1)
        {
            if (IdIsExist(updateId))
            {
                CurrentUpgradesLvl_By_ID[updateId] += numberOfUpgrades;
            }
            throw new NullReferenceException("Id is not correct!");
        }
        public int GetUpgradeLvl(int updateId)
        {
            if (IdIsExist(updateId))
            {
                CurrentUpgradesLvl_By_ID.TryGetValue(updateId, out int lvl);
                return lvl;
            }
            throw new NullReferenceException("Id is not correct!");
        }

        private Dictionary<int, int> CreateUpgradeDictionary(UpgradeModel[] upgrades)
        {
            Dictionary<int, int> currentUpdates = new Dictionary<int, int>();
            for (int i = 0; i < upgrades.Length; i++)
            {
                if (currentUpdates.ContainsKey(upgrades[i].Id))
                    throw new ArgumentException($"You are trying to create UpgradeBundle in which 2 upgrades have the same id: {upgrades[i].Id}. Change ID of {upgrades[i].Name} to resolve the conflict!");
                currentUpdates.Add(upgrades[i].Id, 0);
            }
            return currentUpdates;
        }
        private bool IdIsExist(int updateId)
        {
            return CurrentUpgradesLvl_By_ID.TryGetValue(updateId, out int id);
        }

        bool IUpgradesBundle.IdIsExist(int id) => CurrentUpgradesLvl_By_ID.ContainsKey(id);
    }
}
