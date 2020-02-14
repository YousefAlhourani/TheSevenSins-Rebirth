using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


[System.Serializable]
public class PotionManager : MonoBehaviour, IConsumable
{
    [Serializable] public enum PotionType { HealthPotion, ManaPotion,MegaHealthPotion,MegaManaPotion }
    public PotionType potionTypes;
 
    public void Consume()
    {
        if((int)potionTypes ==0)
        {
            
            GabrielsSystemManager.gabie.Health += 20;
            if(GabrielsSystemManager.gabie.Health>=100)
            {
                GabrielsSystemManager.gabie.Health = 100f;
            }
            
           
        }
        if ((int)potionTypes == 1)
        {
            GabrielsSystemManager.gabie.Stamina += 20;
            if (GabrielsSystemManager.gabie.Stamina >= 100)
            {
                GabrielsSystemManager.gabie.Stamina = 100f;
            }
        }
        if ((int)potionTypes == 2)
        {
            GabrielsSystemManager.gabie.Health += 50;
            if (GabrielsSystemManager.gabie.Health >= 100)
            {
                GabrielsSystemManager.gabie.Health = 100f;
            }
        }
        if ((int)potionTypes==3)
        {
            GabrielsSystemManager.gabie.Stamina += 50;
            if (GabrielsSystemManager.gabie.Stamina >= 100)
            {
                GabrielsSystemManager.gabie.Stamina = 100f;
            }

        }
    }
    public void Consume(GabrielsSystemManager stats)
    {
        throw new NotImplementedException();
    }


  



}
