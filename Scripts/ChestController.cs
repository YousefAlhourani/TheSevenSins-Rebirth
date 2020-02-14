using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Collider[] ItemInChest;
    
    public GameObject PressToInteract;
    Animator anime;

    void Start()
    {
        anime = GetComponent<Animator>();
        for(int i = 0; i < ItemInChest.Length; i++) { ItemInChest[i].enabled = false; }
           
        PressToInteract.SetActive(false);
    }


    public void OnTriggerEnter(Collider other)
    {
       
        PressToInteract.SetActive(true);
        Invoke("TurnOffUI",1f);
            
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("X Button"))
            {
                anime.SetBool("IsOpened", true);
                PressToInteract.SetActive(false);
                GetComponent<Collider>().enabled = false;

                for (int i = 0; i < ItemInChest.Length; i++) { ItemInChest[i].enabled = true; }
            }
        }

    }

    void TurnOffUI()
    {
        PressToInteract.SetActive(false);
    }
   
}
