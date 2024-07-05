using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "Ships/Ship")]
public class ShipData : ScriptableObject
{
    public string shipName;
    public float baseShipDamage;
    public float baseShipHp;
    public float baseShipRepearSpeed;
    public float shipPrice;
    public GameObject shipPrefab;
}




