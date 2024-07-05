using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameManager gameManager;
    public Ship shipsMovement;
    public float EnemyDefaultHp = 100f;
    public float EnemyHP = 100f;
    public float EnemyDamage = 10f;
    public int AliveEnemiesCount = 0 ;

    


    public GameObject EnemyExplotionPrefab;
    public List<GameObject> enemiesPrefabs = new List<GameObject>();
    public List<GameObject> aliveEnemies = new List<GameObject>();
    public List<Transform> EnemiesSpawnPoints = new List<Transform>();

    Vector3 RandomEnemySpawnCoordinates()
    {
        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(12f, 10f);
        return new Vector3(randomX, randomY, 0);
    }

    public float CalculateEnemyDamage()
    {
        return Mathf.RoundToInt(EnemyDamage + Mathf.Pow(1.10f, gameManager.playerGameLevel - 1) * gameManager.playerGameLevel);
    }

    public float CalculateEnemyHp()
    {
        return Mathf.RoundToInt(EnemyDefaultHp + Mathf.Pow(1.10f, gameManager.playerGameLevel - 1) * gameManager.playerGameLevel);
    }

    public void SpawnEnemies()
    {
        
        AliveEnemiesCount = 3;
        if (IsSpawned())
        {
            gameManager.playerGameLevel++;
            for (int i = 0; i < enemiesPrefabs.Count; i++)
            {

                aliveEnemies[i].transform.position = RandomEnemySpawnCoordinates();
                aliveEnemies[i].SetActive(true);
                StartCoroutine(shipsMovement.MoveShipToMarker(aliveEnemies[i].transform, aliveEnemies[i].transform.position, EnemiesSpawnPoints[i].transform.position, 0.5f));
                
            }
        }
        else
        {
            for (int i = 0; i < enemiesPrefabs.Count; i++)
            {

                GameObject spawnedEnemy = Instantiate(enemiesPrefabs[i], RandomEnemySpawnCoordinates(), EnemiesSpawnPoints[i].rotation);
                aliveEnemies.Add(spawnedEnemy);
                
                StartCoroutine(shipsMovement.MoveShipToMarker(spawnedEnemy.transform, spawnedEnemy.transform.position, EnemiesSpawnPoints[i].transform.position, 0.5f));
            }
        }


        

    }

    public void EnemiesTakeDamage(float damage)
    {
        
        EnemyHP -= damage;
        EnemiesDestroyed();
        RespawnIfDead();


    }

    public void DestroyEnemy()
    {
        
            
            GameObject explotion = Instantiate(EnemyExplotionPrefab, aliveEnemies[AliveEnemiesCount - 1].transform.position, Quaternion.identity);
            aliveEnemies[AliveEnemiesCount - 1].SetActive(false);
            AliveEnemiesCount--;

            Destroy(explotion, 2f);
        
        
    }

    public int CalculateAliveEnemies()
    {
        int inactiveCount = 0;
        foreach (GameObject enemy in aliveEnemies)
        {
            if (enemy.activeInHierarchy) 
            {
                inactiveCount++;
            }
        }
        return (inactiveCount);
    }

    public void EnemiesDestroyed()
    {
        for (int i = 0;i < CalculateAliveEnemies();i++)
        {
            if (EnemyHP <= 0)
            {
                if (AliveEnemiesCount > 0)
                {
                    DestroyEnemy();
                }
            }
            else if (EnemyHP <= CalculateEnemyHp() * 0.50)
            {
                if (AliveEnemiesCount > 1)
                {
                    DestroyEnemy();
                }
            }
            else if (EnemyHP <= CalculateEnemyHp() * 0.75)
            {
                if (AliveEnemiesCount > 2)
                {
                    DestroyEnemy();

                }

            }
        }
            
        
        
            
        

    }

    

    public void RespawnIfDead()
    {
        if (EnemyHP <= 0)
        {
            SpawnEnemies();
            EnemyHP = CalculateEnemyHp();
            EnemyDamage = CalculateEnemyDamage();
        }
    }

    bool IsSpawned()
    {
        if (aliveEnemies.Count == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    

}
