using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumShip : Ship
{
    
    protected override void Start()
    {
        

        baseShipDamage = 10f;
        baseShipHp = 30f;
        baseShipRepearSpeed = 600f;
        baseShipTotalSize = 1;



        shipDamageModifier = 1f;
        shipHpModifier = 1f;
        shipTotalModifier = 5;
        shipRepearSpeedModifier = 1f;


        UpdateStats();

        MaxTotalShips = 6;
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
