using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TinyShipsDisplay : MonoBehaviour
{
    //public GameManager gameManager;
    //public EnemyManager1 enemyManager;
    //public GameObject tinyShipPrefab;
    //public GameObject tinyShipShadowPrefab;
    //public GameObject ExplotionPrefab;
    //public List<GameObject> spawnedShips = new List<GameObject>();
    //public List<Transform> spawnMarkers;
    //public int totalShips = 110;
    //public float aliveShips = 0f;
    //public float tinyShipBuildingSpeed = 1f;
    //public float arrivalSpeed = 1f;
    //public TextMeshProUGUI shipsInfoText;
    //public Vector3 startOffset = new Vector3(0, 10, 0);
    //private List<GameObject> spawnedShadows = new List<GameObject>();

    //public float tinyShipsDamage = 10f;

    //private int spawnedShipCount;



    //// Start is called before the first frame update
    //void Start()
    //{
    //    //SpawnShadows();



    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    UpdateShipsInfoUI();
    //    BuildAShip();
    //    DestroyShips();





    //}

    //public IEnumerator TinyShipBuilder()
    //{
    //    while (aliveShips < totalShips)
    //    {

    //        aliveShips += tinyShipBuildingSpeed;
    //        //Debug.Log("Current Value: " + aliveShips);
    //        yield return new WaitForSeconds(1f);


    //    }

    //}



    //void BuildAShip()
    //{
        

    //    while (spawnedShips.Count < ShipsToShow())
    //    {
            

    //            //Vector3 startPosition = spawnMarkers[(ShipsToShow() - 1)].position + startOffset;
    //            GameObject spawnedShip = Instantiate(tinyShipPrefab, RandomSpawnCoordinates(), Quaternion.identity);

    //            spawnedShips.Add(spawnedShip);



    //            StartCoroutine(MoveShipToMarker(spawnedShip.transform, RandomSpawnCoordinates(), spawnMarkers[(spawnedShips.Count - 1)].position, arrivalSpeed));
    //            //Destroy(spawnedShadows[(spawnedShips.Count - 1)]);
            

    //    }
    //}

    //int ShipsToShow()
    //{
        
    //    return Mathf.RoundToInt((float)aliveShips / totalShips * spawnMarkers.Count);

    //}







    //public IEnumerator MoveShipToMarker(Transform shipTransform, Vector3 startPosition, Vector3 targetPosition, float arrivalTime)
    //{

    //    float elapsedTime = 0;


    //    Vector3 direction = (targetPosition - startPosition).normalized;


    //    Vector3 perpendicular = Vector3.Cross(direction, Vector3.forward).normalized;


    //    float distance = Vector3.Distance(startPosition, targetPosition);


    //    float radius = distance / 20;


    //    Vector3 center = (startPosition + targetPosition) / 2 + perpendicular * radius;




    //    while (elapsedTime < arrivalTime)
    //    {
    //        if (shipTransform == null)
    //            yield break;

    //        elapsedTime += Time.deltaTime;
    //        float progress = elapsedTime / arrivalTime;


    //        float angle = Mathf.Lerp(-Mathf.PI, 0, progress);
    //        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
    //        Vector3 position = center + Quaternion.LookRotation(Vector3.forward, -perpendicular) * offset;


    //        shipTransform.position = Vector3.Lerp(position, targetPosition, progress);


    //        yield return null;
    //    }


    //}

    //Vector3 RandomSpawnCoordinates()
    //{
    //    float randomX = Random.Range(-3f, 3f);
    //    float randomY = Random.Range(-10f, -8f);
    //    return new Vector3(randomX, randomY, 0);
    //}



    //void UpdateShipsInfoUI()
    //{

    //    if (shipsInfoText != null)
    //    {
    //        shipsInfoText.text = $"{aliveShips} / {totalShips}";
    //    }
    //}

    //public void SetPrefab(GameObject tinyShipLevel1Prefab)
    //{
    //    tinyShipPrefab = tinyShipLevel1Prefab;

    //    //SpawnShipsAtMarkers();
    //}

    //public void SpawnShadows()
    //{
    //    if (spawnMarkers.Count > 0 && tinyShipShadowPrefab != null)
    //    {
    //        foreach (Transform spawnMarker in spawnMarkers)
    //        {
    //            GameObject spawnedPShadow = Instantiate(tinyShipShadowPrefab, spawnMarker.position, spawnMarker.rotation);
    //            spawnedShadows.Add(spawnedPShadow);
    //        }
    //    }
    //}

    //void toggleBattle()
    //{
    //    if (!gameManager.playerInBattle)
    //    {
    //        StartCoroutine(TinyShipBuilder());
    //    }
    //}

    //public void DestroyShips()
    //{
    //    while (spawnedShips.Count > ShipsToShow())
    //    {
    //        if (spawnedShips[spawnedShips.Count - 1] != null)
    //        {
    //            GameObject explotion = Instantiate(ExplotionPrefab, spawnedShips[spawnedShips.Count - 1].transform.position, Quaternion.identity);
    //            Destroy(spawnedShips[spawnedShips.Count - 1]);
    //            spawnedShips.RemoveAt(spawnedShips.Count - 1);

    //            Destroy(explotion, 2f);
    //        }
            



    //    }
    //}

    //public IEnumerator ShipsTakingDamage()
    //{
    //    while (aliveShips > 0) {
    //        aliveShips -= (float)enemyManager.CalculateEnemyDamage(GameManager.gameLevel);
            
    //        yield return new WaitForSeconds(1f );
    //    }

    //}


    //public void TinyShipsTakesDamage()
    //{
    //    aliveShips -= enemyManager.CalculateEnemyDamage(GameManager.gameLevel);
    //}

    //public float CalculateTinyShipsDamage()
    //{
    //    return tinyShipsDamage * spawnedShips.Count;
    //}
}
