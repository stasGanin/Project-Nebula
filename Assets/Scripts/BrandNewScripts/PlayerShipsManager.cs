using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PlayerShipsManager : MonoBehaviour
{
    public Ship playerShips;
    public Ship[] ships;
    public UpgradeManager upgradeManager;
    public BattleManager battleManager;
    public int AliveFleets ;
    public float shipDamageModifier ;
    public float shipHpModifier;
    

    // Start is called before the first frame update
    void Start()
    {

        AliveFleets = playerShips.fleetSize;
        shipDamageModifier = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {


            DespawnPlayerFleet();
            
        }

        

        if (Input.GetKeyDown(KeyCode.D))
        {

            
        }
    }

    public float CalculateOverallPlayerDamage()
    {
        float playerDamage = 0;
        foreach (Ship ship in ships)
        {

            playerDamage += (float)Math.Round(ship.CalculateShipGroupDamage());
        }
        
        return playerDamage;
    }

    public float CalculatePlayerCurrentHp()
    {
        float playerHp = 0;
        foreach (Ship ship in ships)
        {

            playerHp += ship.GroupHealth;
        }

        return playerHp;
    }

    public float CalculatePlayerTotalHp()
    {
        float MaxHp = 0;
        int fleetCounter = 0;
        foreach (Ship ship in ships)
        {
            if (fleetCounter<playerShips.fleetSize)
            {
                MaxHp += ship.MaxGroupHealth;
            }
                
            fleetCounter++;


        }

        return MaxHp;
    }

    public void PlayerTakesDamage(float damage)
    {
        if (ships[AliveFleets - 1].GroupHealth >= damage)
        {
            ships[AliveFleets - 1].PlayerTakesDamageAndDespawnShips(damage);
        } else if (ships[AliveFleets - 1].GroupHealth < damage)
        {
            ships[AliveFleets - 1].PlayerTakesDamageAndDespawnShips(ships[AliveFleets - 1].GroupHealth);
        }
        
        if (ships[AliveFleets - 1].GroupHealth <= 0)
        {
            AliveFleets--;
        }
    }

    public void StartBuilding()
    {
        AliveFleets = playerShips.fleetSize;
        for (int i = 0; i < playerShips.fleetSize; i++)
        {
            ships[i].RepairShip();
            
        }
    }

    public void StopBuilding()
    {
        for (int i = 0; i < playerShips.fleetSize; i++)
        {
            ships[i].StopRepearing();

        }
    }

    public void StopCoroutinesAndDestroyFleet()
    {
        StopAllPlayerCoroutines();
        DestroyPlayerFleet();
        DespawnPlayerFleet();
    }

    public void UpgradeFleetLevel()
    {
        
        playerShips.fleetSize += 1;
        AliveFleets = playerShips.fleetSize;
        StopCoroutinesAndDestroyFleet();



        for (int i = 0; i < playerShips.fleetSize; i++)
        {
            ships[i].SwapSpawnPoints(playerShips.fleetSize);

        }
        StartBuilding();



    }

    public void DespawnPlayerFleet()
    {
        for (int i = 0; i < playerShips.fleetSize; i++)
        {
            ships[i].DespawnGroup();

        }
    }

    public void DestroyPlayerFleet()
    {
        for (int i = 0; i < playerShips.fleetSize; i++)
        {
            PlayerTakesDamage(CalculatePlayerCurrentHp());

        }
    }

    public void StopAllPlayerCoroutines()
    {
        StopBuilding();
        battleManager.StopBattle();
    }

    
}
