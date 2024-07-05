using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpgradeManager : MonoBehaviour
{
    public GameManager gameManager;
    public Ship[] ships;
    public Ship playerships;
    public PlayerShipsManager playerShipsManager;

    public Upgrade damageUpgrade;
    public Upgrade fleetSizeUpgrade;
    public TextMeshProUGUI DamageUpgradeText;
    public TextMeshProUGUI FleetSizeUpgradeText;

    public TextMeshProUGUI WarningText;


    void Start()
    {
        InitializeUpgrade(damageUpgrade, "Damage", 0, 10, 100, 1.5f, 1, 1.1f);
        InitializeUpgrade(fleetSizeUpgrade, "Fleet", 0, 4, 1000, 10f, 1, 1.1f);
        UpdateButtonText(damageUpgrade, DamageUpgradeText);
        UpdateButtonText(fleetSizeUpgrade, FleetSizeUpgradeText);


    }

    void InitializeUpgrade(Upgrade upgrade, string name, int level, int maxLevel, float baseCost, float costMultiplier, float baseEffect, float effectMultiplier)
    {
        upgrade.upgradeName = name;
        upgrade.level = level;
        upgrade.maxLevel = maxLevel;
        upgrade.baseCost = baseCost;
        upgrade.costMultiplier = costMultiplier;
        upgrade.baseEffect = baseEffect;
        upgrade.effectMultiplier = effectMultiplier;
    }

    public void ApplyUpgrade(Upgrade upgrade, TextMeshProUGUI upgradeText)
    {
        int cost = (int)upgrade.CurrentCost;
        if (upgrade.level < upgrade.maxLevel && gameManager.CanAfford(cost))
        {
            gameManager.SpendMoney(cost);
            upgrade.UpgradeLevel();
            UpdateButtonText(upgrade, upgradeText);
        }
        else if (!gameManager.CanAfford(cost))
        {
            WarningText.text = "Not enough money";
        }
        else
        {
            WarningText.text = "Max Level Reached";
        }
    }
    //----------------------UI------------------------------------
    void UpdateButtonText(Upgrade upgrade, TextMeshProUGUI upgradeText )
    {
        upgradeText.text = $"Upgrade {upgrade.upgradeName}: Level {upgrade.level}/{upgrade.maxLevel}\nCost: {upgrade.CurrentCost}";
    }

    //------------------------INIQUEUPGRADESDEPENDENCIES------------------






    //------------------------UPGRADEVOIDS------------------
    public void OnUpgradeDamageClicked()
    {
        ApplyUpgrade(damageUpgrade, DamageUpgradeText);
        foreach (Ship ship in ships)
        {
            ship.shipDamageModifier = damageUpgrade.CurrentEffect;
            ship.SetAndUpdateStats();
        }
    }

    public void OnUpgradeFleetSizeClicked()
    {
        if (gameManager.CanAfford(fleetSizeUpgrade.CurrentCost))
        {
            ApplyUpgrade(fleetSizeUpgrade, FleetSizeUpgradeText);
            playerShipsManager.UpgradeFleetLevel();

        }

        

    }



}
