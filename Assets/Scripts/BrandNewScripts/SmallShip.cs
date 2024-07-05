using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShip : Ship
{
    protected override void Start()
    {
        baseShipDamage = shipData.baseShipDamage;
        baseShipHp = shipData.baseShipHp;
        baseShipRepearSpeed = shipData.baseShipRepearSpeed;
        shipPrefab = shipData.shipPrefab;




    shipDamageModifier = 1f;
        shipHpModifier = 1f;
        shipTotalModifier = 10;
        shipRepearSpeedModifier = 1f;

        


        baseShipTotalSize = 1;
        MaxTotalShips = 11;
        shipSpeed = 5f;
        UpdateStats();

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
