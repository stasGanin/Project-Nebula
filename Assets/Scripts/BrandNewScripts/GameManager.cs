using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyManager enemyManager;
    public int playerGameLevel = 1;
    public float PlayerMoney = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemyManager.SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanAfford(float amount)
    {
        return PlayerMoney >= amount;
    }

    // Метод для списания денег
    public void SpendMoney(float amount)
    {
        if (CanAfford(amount))
        {
            PlayerMoney -= amount;
        }
    }

    public void GreedIsGood()
    {
        PlayerMoney += 10000;
    }
}
