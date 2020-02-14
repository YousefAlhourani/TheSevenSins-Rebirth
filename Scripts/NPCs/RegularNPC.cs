using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularNPC : NPC
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("interacted with regular NPC");
    }
}
