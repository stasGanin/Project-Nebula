using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade 
{
    public string upgradeName;        
    public int level;                 
    public int maxLevel;              
    public float baseCost;            
    public float costMultiplier;      
    public float baseEffect;          
    public float effectMultiplier;

    public float CurrentCost          
    {
        get { return baseCost * Mathf.Pow(costMultiplier, level); }
    }

    public float CurrentEffect        
    {
        get { return baseEffect * Mathf.Pow(effectMultiplier, level); }
    }

    

    public bool UpgradeLevel()
    {
        if (level < maxLevel)
        {

            level++;
            return true; 
        }
        return false; 
    }


}
