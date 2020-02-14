using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This Script Might Be useFull if I add a Crafting System Later On , At The Moment only putting it as testing for the item database,
 * 
 */
public class CraftRecipe 
{
    public int[] requiredItems;
    public int itemToCraft;

    public CraftRecipe(int itemToCraft,int[]requiredItems)
    {
        this.requiredItems = requiredItems;
        this.itemToCraft = itemToCraft;

    }
}
