using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShip : Ship
{
    protected override void Start()
    {
        baseShipDamage = 100f;
        baseShipHp = 300f;
        baseShipRepearSpeed = 6000f;
        baseShipTotalSize = 1;



        shipDamageModifier = 1f;
        shipHpModifier = 1f;
        shipTotalModifier = 0;
        shipRepearSpeedModifier = 1f;


        UpdateStats();

        MaxTotalShips = 3;
        shipSpeed = 5f;

        base.Start();
    }

    public void UpdateStats()
    {
        ShipHealth = baseShipHp * shipHpModifier;
        RepairSpeed = baseShipRepearSpeed * shipRepearSpeedModifier;
        ShipsTotal = baseShipTotalSize + shipTotalModifier;
        MaxGroupHealth = ShipsTotal * ShipHealth;
        shipDamage = baseShipDamage * shipDamageModifier;
    }
}
