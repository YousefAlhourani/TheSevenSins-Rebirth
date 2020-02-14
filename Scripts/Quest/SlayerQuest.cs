using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayerQuest : Quest
{
   
    void Start()
    {
        QuestName = "Slayer Quest";
        Description = "Kill A Number Of Monsters";
        questType = QuestType.Killing;
        ItemReward = "Health Potion";
        
        
        Goals.Add(new KillGoal(this,0,"Kill 3 SkeletonKnights",false,0,3));
       

        Goals.ForEach(g => g.Init());
    }

    
    public override void GiveReward()
    {
        if(ItemReward!=null)
        {
            Debug.Log("Has Given"+ItemReward);
            InventoryController.Instance.GiveItem(ItemReward);
           
        }
    }


}
