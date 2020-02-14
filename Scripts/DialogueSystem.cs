using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }
    public string npcName;

  
    public List<string> dialogueLines = new List<string>();

    public bool isDoneDialogue = false;

    //Dialogue UI Components
    public GameObject dialoguePanel;
    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;
    public string otherCharacter;

    private void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialogueText = dialoguePanel.transform.Find("BoxBackGround").Find("Dialogue").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("BoxBackGround").Find("NPC_NAME").GetComponent<Text>();
        dialoguePanel.SetActive(false);
        


        if(Instance!=null && Instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public void AddNewDialogue(string[] lines,string npcName)
    {
        isDoneDialogue = false;
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);  //Resets the dialogue
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        
        CreateDialogue();
    }
    public void UpdateCharacterName(string charName)
    {
        otherCharacter = charName;
    }
    public void CreateDialogue()
    {
        
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
        continueButton.Select();
        
        
    }
   
    public void ContinueDialogue()
    {
        if(dialogueIndex <dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            isDoneDialogue = true;
        }
        if(dialogueIndex%2==0)
        {
            nameText.text = npcName;
        }
        else
        if(otherCharacter!=null)
        {
            nameText.text = otherCharacter;
        }
    }

   public void ExitDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueIndex = 0;
        isDoneDialogue = false;
    }

   

    

}
