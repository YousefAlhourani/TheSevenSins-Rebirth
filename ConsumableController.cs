using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    GabrielsSystemManager stats;

     void Start()
    {
        stats = GetComponent<GabrielsSystemManager>();
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToConsume = Instantiate(Resources.Load<GameObject>("Consumables/" + item.itemName));
        if (item.ItemModifier)
        {
            
            itemToConsume.GetComponent<IConsumable>().Consume(stats);

            Destroy(itemToConsume);
           
        }
        else
        {
            
            itemToConsume.GetComponent<IConsumable>().Consume();
            Destroy(itemToConsume);
            
        }
        

       
    }

  
}
