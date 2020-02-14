using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    
    [SerializeField] public enum QuestType { StoryLine, SideQuest, BanterTalk}
    public QuestType questType;
    public GameObject PopUpSign;
    private bool isInteract = false;
   

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            isInteract = true;
            
            PopUpSign.SetActive(true);
        }
       
    }

   

  
   
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
           
            
            if (Input.GetButtonDown("X Button")&&isInteract)
            {
                    PopUpSign.SetActive(false);
                    
                    isInteract = false;
                    gameObject.GetComponent<Interactable>().Interact();
                    GabrielsSystemManager.gabie.PauseCharacter();     
            }
           
                
               
           





            //Story Quest
            if ((int)questType == 0)
            {
               
            }

            //Side Quest
            if ((int)questType == 1)
            {
                
                SideQuest();

            }

            //NoQuestJustDialouge
            if ((int)questType == 2)
            {
                RandomDialogue();
            }


            if (Input.GetButtonDown("B Button"))
            {
                DialogueSystem.Instance.ExitDialogue();
                isInteract = true;
                GabrielsSystemManager.gabie.ResumeCharacter();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            
            isInteract = false;
            
            PopUpSign.SetActive(false);
        }
    }






    //SideQuest enum
    void SideQuest()
    {

        if (DialogueSystem.Instance.isDoneDialogue)
        {
           
            if (gameObject.GetComponent<QuestGiver>() != null)
            {
               
                gameObject.GetComponent<QuestGiver>().OpenUpQuestUI();
                DialogueSystem.Instance.isDoneDialogue = false;
                if (!gameObject.GetComponent<QuestGiver>().CheckifUIisOpen())
                {
                    GabrielsSystemManager.gabie.ResumeCharacter();
                    isInteract = true;
                    PopUpSign.SetActive(true);

                }

            }

        }
    }

 

    //BanterTalk enum
    void RandomDialogue()
    {
        if(DialogueSystem.Instance.isDoneDialogue)
        {
            DialogueSystem.Instance.isDoneDialogue = false;
            GabrielsSystemManager.gabie.ResumeCharacter();
            isInteract = true;
            PopUpSign.SetActive(true);

        }
    }

   





}
