using System.Collections;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    [HideInInspector]
    
    public virtual void Interact()
    {
        Debug.Log("Interacted With Base Class");
    }
}
