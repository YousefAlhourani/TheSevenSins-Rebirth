using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbCollection : Quest
{
    string ItemReward2;
    string ItemReward3;
    void Start()
    {
        
        QuestName = "Herb Collection";
        Description = "Retrieve 4 Wolfs Bane Herbs For The Chemist";
        questType = QuestType.Collecting;

        Goals.Add(new CollectionGoal(this, 5, "Gather Three Wolfs Bane Herbs For The Chemist", false, 0, 3));
        ItemReward = "Mega Health Potion";
        ItemReward2 = "Mega Health Potion";
        ItemReward3 = "Mega Mana Potion";
        Goals.ForEach(g => g.Init());
    }
    public override void GiveReward()
    {   
        if (ItemReward != null)
        {
            /*
             * UIEventHandler is a script that holds a group of delegate methods for updating Inventory UI
             * Based on Either Adding Or Removing Item.
             */
            Item item = ItemDatabase.instance.GetItem("Wolfs Bane");
            UIEventHandler.ItemRemovedFromInventory(item);
            UIEventHandler.ItemRemovedFromInventory(item);
            UIEventHandler.ItemRemovedFromInventory(item);
            UIEventHandler.ItemRemovedFromInventory(item);

            //Rewarding
            InventoryController.Instance.GiveItem(ItemReward);
            InventoryController.Instance.GiveItem(ItemReward2);
            InventoryController.Instance.GiveItem(ItemReward3);
        }
    } 
}
