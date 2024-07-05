using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShip", menuName = "Space Game/Ship", order = 0)]
public class ShipCreation : ScriptableObject
{
    
    
        public string shipName;
        public GameObject shipPrefab;
        public int health;
        public float speed;
        // Добавьте другие параметры, которые могут быть нужны для вашего корабля.
    
}
