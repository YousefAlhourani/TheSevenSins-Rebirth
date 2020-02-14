using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
   
   [SerializeField] Slider healthSlider; //for his Health Ability;
   [SerializeField] Slider staminaSlider; //for his Stamina Ability;
   [SerializeField] GabrielsSystemManager player;
   
    void Start()
   {
        player=GabrielsSystemManager.gabie;
   }

   void Update()
   {
        if (player != null)
        {
            healthSlider.value = player.Health;
            staminaSlider.value = player.Stamina;
        }


       
   }

 
}
