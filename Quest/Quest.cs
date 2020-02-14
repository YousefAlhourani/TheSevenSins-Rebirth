using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public enum QuestType { Collecting,Killing}
    public QuestType questType;
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public string ItemReward { get; set; } 

    public  void CheckGoals()
    {
        //Requires Header System.Linq;
        Completed = Goals.All(g => g.Completed);  
    }

    public virtual void GiveReward()
    {
        Debug.Log("Reward From Quest Class");
    }
}
