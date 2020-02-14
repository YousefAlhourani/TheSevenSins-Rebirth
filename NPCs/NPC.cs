using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;   //Holds the sentences you would like to be spoken
    public string npcName;      //name of character who says the first sentence.
    public string OtherNpcName; //name of character who says the second sentence.

    public override void Interact()
    {
        base.Interact();
        /*
         *The following If statement is to check if the dialogue is between the NPC and the Player or just a 
         * monologue from the NPC alone.
         */
        if(!string.IsNullOrEmpty(OtherNpcName))
        {
            DialogueSystem.Instance.UpdateCharacterName(OtherNpcName);
        }
        else if(string.IsNullOrEmpty(OtherNpcName))
        {
            DialogueSystem.Instance.UpdateCharacterName(npcName);
        }
        DialogueSystem.Instance.AddNewDialogue(dialogue,npcName);   
    }
}
