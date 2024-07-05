using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public PlayerShipsManager PlayerShipsManager;
    public Ship playerships;
    public EnemyManager enemyManager;
    public GameManager gameManager;
    public bool isInBattle = false;
    public Coroutine BattleCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShipsManager.StartBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            ToggleBattle();


        }
    }

    public void ToggleBattle()
    {
        isInBattle = !isInBattle;

        if (!isInBattle)
        {
            StopBattle();
            PlayerShipsManager.StartBuilding();
        }
        else if (isInBattle)
        {
            StartBattle();
            PlayerShipsManager.StopBuilding();
        }
    }



    public IEnumerator InBattleCoroutine()
    {
        
        while (PlayerShipsManager.CalculatePlayerCurrentHp() > 0 && isInBattle)
        {
            yield return new WaitForSeconds(1f);
            if (PlayerShipsManager.CalculateOverallPlayerDamage() < enemyManager.EnemyHP)
            {
                gameManager.PlayerMoney += PlayerShipsManager.CalculateOverallPlayerDamage();
            }
            else if (PlayerShipsManager.CalculateOverallPlayerDamage() >= enemyManager.EnemyHP)
            {
                gameManager.PlayerMoney += enemyManager.EnemyHP;
            }
            enemyManager.EnemiesTakeDamage(PlayerShipsManager.CalculateOverallPlayerDamage());
            PlayerShipsManager.PlayerTakesDamage(enemyManager.CalculateEnemyDamage());

            

            


        }
        
    }

    public void StartBattle()
    {
        if (BattleCoroutine == null) {
            BattleCoroutine = StartCoroutine(InBattleCoroutine());
        }
        
    }

    public void StopBattle()
    {
        if (BattleCoroutine != null)
        {
            StopCoroutine(BattleCoroutine);
            BattleCoroutine = null;
        }
        
    }




}
