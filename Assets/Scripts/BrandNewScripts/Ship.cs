using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public ShipData shipData;

    public float GroupHealth;
    public float MaxGroupHealth;
    public float ShipHealth;
    public float RepairSpeed;
    public float MaxTotalShips;
    public int ShipsTotal;
    public int ShipsAlive;
    public float shipSpeed;
    public float shipDamage;
    public float shipDamageModifier;
    public float shipHpModifier;
    public float shipRepearSpeedModifier;
    public int shipTotalModifier;
    public float baseShipDamage;
    public float baseShipHp;
    public float baseShipRepearSpeed;
    public int baseShipTotalSize;

    public Coroutine RepearingCoroutine;

    
    
    public int fleetSize;
    public GameObject explotionPrefab;
    public GameObject shipPrefab;
    public Transform[] shipSpawnPointsNow;
    public Transform[] shipSpawnPoints1;
    public Transform[] shipSpawnPoints2;
    public Transform[] shipSpawnPoints3;
    public Transform[] shipSpawnPoints4;
    public Transform[] shipSpawnPoints5;
    public List<GameObject> AliveShips = new List<GameObject>();
    // Start is called before the first frame update


    protected virtual void Start()
    {
        
        GroupHealth = 0;
        ShipsAlive = 0;
        fleetSize = 1;

        SwapSpawnPoints(fleetSize);
    }

    public void SetAndUpdateStats()
    {
        ShipHealth = baseShipHp * shipHpModifier;
        RepairSpeed = baseShipRepearSpeed * shipRepearSpeedModifier;
        ShipsTotal = baseShipTotalSize + shipTotalModifier;
        MaxGroupHealth = ShipsTotal * ShipHealth;
        shipDamage = baseShipDamage * shipDamageModifier;
    }

    public void RepairShip()
    {
        if (RepearingCoroutine == null)
        {
            RepearingCoroutine = StartCoroutine(BuildingCoroutine());
            
        }


    }

    public void StopRepearing()
    {
        
        if (RepearingCoroutine != null)
        {
            StopCoroutine(RepearingCoroutine);
            RepearingCoroutine = null; 
        }
        
    }

    private IEnumerator BuildingCoroutine()
    {
        
        GameObject shipToActivate = null;
        
        while (GroupHealth < MaxGroupHealth)
        {
            if ((MaxGroupHealth - GroupHealth) < RepairSpeed)
            {
                GroupHealth = MaxGroupHealth;
            }
            else
            {
                GroupHealth += RepairSpeed;
            }

            
            while (GroupHealth >= ShipHealth * ShipsAlive && ShipsAlive < ShipsTotal)
            {

               
                foreach (GameObject ship in AliveShips)
                {
                    


                    if (!ship.activeInHierarchy)
                    {
                        shipToActivate = ship;
                        

                        break;
                    }
                }

                
                if (shipToActivate != null)
                {
                    
                    shipToActivate.SetActive(true);
                    shipToActivate.transform.position = RandomSpawnCoordinates();
                    StartCoroutine(MoveShipToMarker(shipToActivate.transform, shipToActivate.transform.position, shipSpawnPointsNow[ShipsAlive].position, 1f / shipSpeed));
                    ShipsAlive++;
                    
                }
                else if (AliveShips.Count < ShipsTotal)
                {
                    GameObject spawnedShip = Instantiate(shipPrefab, RandomSpawnCoordinates(), Quaternion.identity);
                    AliveShips.Add(spawnedShip);
                    StartCoroutine(MoveShipToMarker(spawnedShip.transform, spawnedShip.transform.position, shipSpawnPointsNow[ShipsAlive].position, 1f / shipSpeed));
                    ShipsAlive++;
                }
                
            }
            
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator MoveShipToMarker(Transform shipTransform, Vector3 startPosition, Vector3 targetPosition, float arrivalTime)
    {

        float elapsedTime = 0;


        Vector3 direction = (targetPosition - startPosition).normalized;


        Vector3 perpendicular = Vector3.Cross(direction, Vector3.forward).normalized;


        float distance = Vector3.Distance(startPosition, targetPosition);


        float radius = distance / 20;


        Vector3 center = (startPosition + targetPosition) / 2 + perpendicular * radius;




        while (elapsedTime < arrivalTime)
        {
            if (shipTransform == null)
                yield break;

            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / arrivalTime;


            float angle = Mathf.Lerp(-Mathf.PI, 0, progress);
            Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Vector3 position = center + Quaternion.LookRotation(Vector3.forward, -perpendicular) * offset;


            shipTransform.position = Vector3.Lerp(position, targetPosition, progress);


            yield return null;
        }


    }

    Vector3 RandomSpawnCoordinates()
    {
        float randomX = Random.Range(-3f, 3f);
        float randomY = Random.Range(-10f, -8f);
        return new Vector3(randomX, randomY, 0);
    }

    public void DestroyPlayerShips()
    {
        while (GroupHealth <= (ShipHealth * (ShipsAlive-1)) && ShipsAlive>0)
        {

            for (int i = AliveShips.Count - 1; i >= 0; i--)
            {
                if (AliveShips[i].activeSelf)
                {
                    AliveShips[i].SetActive(false);
                    GameObject explotion = Instantiate(explotionPrefab, AliveShips[i].transform.position, Quaternion.identity);
                    Destroy(explotion, 2f);
                    ShipsAlive--;
                    break;
                }
            }


        }
        
    }

    private float PlayerShipsTakesDamage(float damage)
    {
        return GroupHealth -= damage;
        

    }



    public void PlayerTakesDamageAndDespawnShips(float damage)
    {
        
        PlayerShipsTakesDamage(damage);
        //if (GroupHealth < ShipHealth)
        //{
        //    PlayerShipsTakesDamage(GroupHealth);
        //}
        if (damage > GroupHealth)
        {
            PlayerShipsTakesDamage(GroupHealth);
        }
            DestroyPlayerShips();
    }

    public float CalculateShipGroupDamage()
    {
        return ShipsAlive * shipDamage;
    }

    public void SwapSpawnPoints(int totalFleets)
    {
        switch (totalFleets)
        {
            case 1:
                shipSpawnPointsNow = shipSpawnPoints1;
                break;
            case 2:
                shipSpawnPointsNow = shipSpawnPoints2;
                break;
            case 3:
                shipSpawnPointsNow = shipSpawnPoints3;
                break;
        }

    }

    public void DespawnGroup()
    {
        foreach (var obj in AliveShips)
        {
            Destroy(obj);
        }

        AliveShips.Clear();
    }

    



}
