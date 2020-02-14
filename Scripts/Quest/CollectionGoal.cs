using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public int ItemID { get; set; }
    
    public CollectionGoal(Quest quest,int itemID,string description,bool completed,int currentAmount,int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnItemAddedToInventory += ItemCollected;
        
    }

    void ItemCollected(Item item)
    {
        
        if(item.itemID==this.ItemID)
        {
            this.CurrentAmount++;
            Debug.Log("Quest Item Taken" + item.itemName);
            Debug.Log(CurrentAmount.ToString());
            EvaluateProgress();
        } 
        
    }
}
