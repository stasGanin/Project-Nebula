using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerOld : MonoBehaviour
{

    //private float timer = 0f;
    //private float interval = 0.1f;


    //public TinyShipsDisplay tinyShipsDisplay;
    //public EnemyManager1 enemyManager;
    //public static int gameLevel = 1;
    //public bool playerInBattle = false;
    //private Coroutine buildingCorutine = null;
    //private Coroutine fightingCorutine = null;
    //private bool isFighting = false;
    //private bool isBuilding = false; 

    //private Coroutine EnemyTakesDamageWhileBattle = null;
    //public GameObject upgradeMenuCanvas;
    //public GameObject returnToBattleScreen;

    //public float playerMoney = 0;
    //public TextMeshProUGUI playerMoneyText;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= interval)
    //    {
    //        GameStateCheck();
    //        RestartWhileDead();
    //        CheckAndLvlup();
    //        PlayerMoneyUi();
    //        //StopIfFull();

    //        // Выполнить операцию
    //        timer = 0f;
    //    }
        

    //}

    //public void ToBattle()
    //{
    //    playerInBattle = !playerInBattle;

        

        
    //}

    //void GameStateCheck()
    //{
    //    if (!playerInBattle)
    //    {
    //        StartBuilding();


    //    }
    //    else if (playerInBattle)
    //    {
    //        StartBattle();
    //    } 
    //}

    //public bool PlayerIsDead()
    //{
    //    if (tinyShipsDisplay.aliveShips <= 0)
    //    {
    //        return true;
    //    } else
    //    {
    //        return false;
    //    }
        
    //}

    //public bool PlayerIsFull()
    //{
    //    if (tinyShipsDisplay.aliveShips >= tinyShipsDisplay.totalShips)
    //    {
    //        return true;
    //    } else
    //    {
    //        return false;
    //    }
        
    //}

    //void RestartWhileDead()
    //{
    //    if (PlayerIsDead())
    //    {
    //        ToBattle();
    //    }

        
    //}

    //void StopIfFull()
    //{
    //    if (PlayerIsFull())
    //    {
    //        ToBattle();
    //    }
    //}

    //void StartBattle()
    //{
    //    if (!isFighting) 
    //    {
    //        if (buildingCorutine != null)
    //        {
    //            StopCoroutine(buildingCorutine);
    //            buildingCorutine = null;
    //        }
    //        fightingCorutine = StartCoroutine(tinyShipsDisplay.ShipsTakingDamage());
    //        EnemyTakesDamageWhileBattle = StartCoroutine(enemyManager.EnemyTakesDamage());
    //        isFighting = true;
    //        isBuilding = false;
    //    }
    //}

    //void StartBuilding()
    //{
    //    if (!isBuilding) 
    //    {
    //        if (fightingCorutine != null && EnemyTakesDamageWhileBattle != null)
    //        {
    //            StopCoroutine(fightingCorutine);
    //            StopCoroutine(EnemyTakesDamageWhileBattle);
    //            fightingCorutine = null;
    //            EnemyTakesDamageWhileBattle = null;
    //        }
    //        buildingCorutine = StartCoroutine(tinyShipsDisplay.TinyShipBuilder());
    //        isBuilding = true;
    //        isFighting = false;
    //    }
    //}

    //void CheckAndLvlup()
    //{
    //    if (enemyManager.currentEnemyHealth <= 0)
    //    {
    //        //playerMoney += enemyManager.CalculateEnemyHealth(gameLevel);
    //        gameLevel += 1;
    //        enemyManager.SpawnEnemyAtPoints();
    //    }
    //}

    

    //public void OpenUpgradeMenu()
    //{
    //    if (!upgradeMenuCanvas.activeSelf)
    //    {
    //        upgradeMenuCanvas.SetActive(true);
    //    }


    //}

    //public void OpenBattleMenu()
    //{
    //    if (upgradeMenuCanvas.activeSelf)
    //    {
    //        upgradeMenuCanvas.SetActive(false);
    //    }


    //}

    //public void PlayerMoneyUi()
    //{

    //    if (playerMoneyText != null)
    //    {
    //        playerMoneyText.text = $"{playerMoney}";
    //    }
    //}


}
