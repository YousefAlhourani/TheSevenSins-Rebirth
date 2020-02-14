using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayerQuest2 : Quest
{
    
    void Start()
    {
        QuestName = "Slayer Quest 2";
        Description = "A Horde Of Monsters Must Be Defeated";
        questType = QuestType.Killing;
        ItemReward = "Mana Potion";

        Goals.Add(new KillGoal(this, 0, "Kill The Horde Of Skeleton Knights", false, 0, 4));
        Goals.Add(new KillGoal(this, 1, "Kill The Necromancer ",false, 0, 1));

        Goals.ForEach(g => g.Init());
        
    }
    
    public override void GiveReward()
    {
        if (ItemReward != null)
        {
            
            InventoryController.Instance.GiveItem(ItemReward);
        }
    }


}
