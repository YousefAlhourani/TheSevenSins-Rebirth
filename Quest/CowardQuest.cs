using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowardQuest : Quest
{
    private void Start()
    {
        QuestName = "Cowards Quest";

        Description = "Find The Cowards Lost Treasure Around His House";

        questType = QuestType.Collecting;

        Goals.Add(new CollectionGoal(this, 7, "Find The Treasure", false, 0,1));

        ItemReward = "Health Potion";

        Goals.ForEach(g => g.Init());
    }

    public override void GiveReward()
    {
        if(ItemReward != null)
        {
            InventoryController.Instance.GiveItem(ItemReward);
            Item item = ItemDatabase.instance.GetItem("Gold Ring");
            UIEventHandler.ItemRemovedFromInventory(item);
            UIEventHandler.ItemRemovedFromInventory(item);

            
        }
    }
}
