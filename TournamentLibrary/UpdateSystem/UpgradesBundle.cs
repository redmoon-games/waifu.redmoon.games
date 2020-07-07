using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.UpdateSystem
{
    public abstract class UpgradesBundle : IUpgradesBundle
    {
        public Dictionary<int, int> UpgradeLvlByID { get; }

        private readonly UpgradeModel[] _upgradesTemplate;

        public UpgradesBundle(UpgradeModel[] upgrades)
        {
            _upgradesTemplate = upgrades;
            UpgradeLvlByID = CreateUpgradeDictionary(upgrades);
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
                UpgradeLvlByID[updateId] += numberOfUpgrades;
            }
            throw new NullReferenceException("Id is not correct!");
        }
        public int GetUpgradeLvl(int updateId)
        {
            if (IdIsExist(updateId))
            {
                UpgradeLvlByID.TryGetValue(updateId, out int lvl);
                return lvl;
            }
            throw new NullReferenceException("Id is not correct!");
        }

        private Dictionary<int, int> CreateUpgradeDictionary(UpgradeModel[] upgrades)
        {
            Dictionary<int, int> currentUpdates = new Dictionary<int, int>();
            for (int i = 0; i < upgrades.Length; i++)
            {
                currentUpdates.Add(i, 0);
            }
            return currentUpdates;
        }
        private bool IdIsExist(int updateId)
        {
            return UpgradeLvlByID.TryGetValue(updateId, out int id);
        }
    }
}
