using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager1 : MonoBehaviour
{

    //public GameManager gameManager;
    //public TinyShipsDisplay tinyShipsStats;


    //public int enemyBaseDamage = 10;
    //public int enemyBaseHealth = 100;
    //public float currentEnemyHealth = 1f;
    //public TextMeshProUGUI EnemyHPInfo;
    //public List<GameObject> EnemiesPrefabs = new List<GameObject>();
    //public List<GameObject> spawnedEnemies = new List<GameObject>();
    //public List<Transform> EnemiesSpawnPoints = new List<Transform>();
    //public Vector3 startEnemyOffset = new Vector3(0, -10, 0);
    //public GameObject EnemyExplotionPrefab;


    //private float timer = 0f;
    //private float interval = 0.1f;



    //// Start is called before the first frame update
    //void Start()
    //{
    //    SpawnEnemyAtPoints();
        
    //}


    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime; //Таймер для оптимиазации всякого
    //    if (timer >= interval)
    //    {
    //        UpdateEnemyInfoUI();
    //        DestroyEnemies();

            
    //        timer = 0f;
    //    }
        
    //}

    //public void SpawnEnemyAtPoints()
    //{
    //    currentEnemyHealth = CalculateEnemyHealth(GameManager.gameLevel);
    //    for (int i = 0; i < EnemiesPrefabs.Count; i++)
    //    {
    //        // Спавним врага на позиции
    //        GameObject spawnedEnemy = Instantiate(EnemiesPrefabs[i], RandomEnemySpawnCoordinates(), EnemiesSpawnPoints[i].rotation);
    //        spawnedEnemies.Add(spawnedEnemy);
    //        StartCoroutine(tinyShipsStats.MoveShipToMarker(spawnedEnemy.transform, spawnedEnemy.transform.position, EnemiesSpawnPoints[i].transform.position,0.5f));
    //    }


    //}

    //public int CalculateEnemyDamage(int level)
    //{
    //    return Mathf.RoundToInt(enemyBaseDamage + Mathf.Pow(1.05f, level - 1) * level);
        
    //}

    //public float CalculateEnemyHealth(int level)
    //{
    //    return Mathf.RoundToInt(enemyBaseHealth * Mathf.Pow(1.1f, level - 1));
    //}


    
    

    //void UpdateEnemyInfoUI()
    //{

    //    if (EnemyHPInfo != null)
    //    {
    //        EnemyHPInfo.text = $"{currentEnemyHealth} / {CalculateEnemyHealth(GameManager.gameLevel)}";
    //    }
    //}

    //public IEnumerator EnemyTakesDamage()
    //{
    //    while (currentEnemyHealth > 0)
    //    {
    //        gameManager.playerMoney += tinyShipsStats.CalculateTinyShipsDamage() / 2;
    //        currentEnemyHealth -= tinyShipsStats.CalculateTinyShipsDamage() / 2;
            
    //        yield return new WaitForSeconds(1f);
    //    }
    //}

    //public void DestroyEnemies()
    //{

    //    if (currentEnemyHealth == 0)
    //    {
    //        if (spawnedEnemies.Count > 0)
    //        {
    //            DestroyEnemy();
    //        }
    //    }
    //    else if (currentEnemyHealth <= CalculateEnemyHealth(GameManager.gameLevel) * 0.33)
    //    {
    //        if (spawnedEnemies.Count > 1)
    //        {
    //            DestroyEnemy();
    //        }
    //    }
    //    else if (currentEnemyHealth <= CalculateEnemyHealth(GameManager.gameLevel) * 0.66)
    //    {
    //        if (spawnedEnemies.Count > 2)
    //        {
    //            DestroyEnemy();
    //        }

    //    }  
        
    //}

    //public void DestroyEnemy()
    //{
    //    GameObject explotion = Instantiate(EnemyExplotionPrefab, spawnedEnemies[spawnedEnemies.Count - 1].transform.position, Quaternion.identity);
    //    Destroy(spawnedEnemies[spawnedEnemies.Count - 1]);
    //    spawnedEnemies.RemoveAt(spawnedEnemies.Count - 1);
        
    //    Destroy(explotion, 2f);
    //}

    //Vector3 RandomEnemySpawnCoordinates()
    //{
    //    float randomX = Random.Range(-5f, 5f);
    //    float randomY = Random.Range(12f, 10f);
    //    return new Vector3(randomX, randomY, 0);
    //}

}
