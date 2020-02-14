using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    [SerializeField] private GameObject quests;
    [SerializeField] private string questType;
    private Quest Quest { get; set; }

    [SerializeField] private string questDescription;
    [SerializeField] private string questTitle;
    [SerializeField] private string[] responseAfterQuest;
    [SerializeField] private string[] notCompletedQuestDialogue;
    [SerializeField] private string[] rejectedQuest;
    private bool isCompleted = false;
    private bool isRejected = false;

    
    //UI Related Components.

    public GameObject questUI;
    public Button acceptQuest;
    public Text questName;
    public Text questDetails;
    public GameObject rewardScreen;
    public Text itemNameText;

    private void Awake()
    {
        //PlayerPrefs.SetInt("QuestStatus" + questType, 0); //To Do : Remove This Line Once Done Testing.
        if (PlayerPrefs.GetInt("QuestStatus" + questType, 0) == 1)
        {
            isCompleted = true;
        }
        else
            isCompleted = false;
            

    }

   

    public override void Interact()
    {
        if (PlayerPrefs.GetInt("QuestStatus" + questType) == 0)
        {
            if (!AssignedQuest && !Helped&&!isRejected)
            {
                base.Interact();

            }
            else if (AssignedQuest && !Helped)
            {
                isRejected = false;
                CheckQuest();
            }
            else if(!AssignedQuest&&!Helped&&isRejected)
            {
                DialogueSystem.Instance.AddNewDialogue(rejectedQuest, npcName);
            }
        }
        else if(PlayerPrefs.GetInt("QuestStatus"+questType)==1)
        {
            DialogueSystem.Instance.AddNewDialogue(responseAfterQuest, npcName);
        }
    }

    public void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        questUI.SetActive(false);
        GabrielsSystemManager.gabie.ResumeCharacter();
    }

    void CheckQuest()
    {
        if (!isCompleted)
        {
            if (Quest.Completed)
            {
                PlayerPrefs.SetInt("QuestStatus" + questType, 1);
                Quest.GiveReward();
                isCompleted = true;
                Helped = true;
                AssignedQuest = false;
                itemNameText.text = Quest.ItemReward;
                DialogueSystem.Instance.AddNewDialogue(responseAfterQuest, npcName);
                rewardScreen.SetActive(true);
                Invoke("ShowRewardPopUp", 1.5f);


            }
            else
                DialogueSystem.Instance.AddNewDialogue(notCompletedQuestDialogue, npcName);
        }
    }

 

    public void OpenUpQuestUI()
    {
        if (!isCompleted)
        {
            if (AssignedQuest)
            {
                questUI.SetActive(false);
                

            }
            else
            {
                questUI.SetActive(true);
                acceptQuest.Select();
                questName.text = questTitle;
                questDetails.text = questDescription;
            }
        }   
       
    }

    public void RejectQuest()
    {
        isRejected = true;
        questUI.SetActive(false);
        GabrielsSystemManager.gabie.ResumeCharacter(); 
    }
    
    public bool CheckifUIisOpen()
    {
        if(questUI.activeSelf)
        {
            return true;
        }
       else
        {
            return false;
        }
    }
    public void ShowRewardPopUp()
    {
        rewardScreen.SetActive(false);
        GabrielsSystemManager.gabie.ResumeCharacter();
    }
  
}
