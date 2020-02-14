using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomHintOnLoadingScreen : MonoBehaviour
{
    private string randomText;
    private void Start()
    {
        RandomTextOnLoadingScreen();
    }

    private void RandomTextOnLoadingScreen()
    {
        int Case=Random.Range(1, 4);

        switch(Case)
        {

            case 1:
                randomText = "Interacting With The Fire Pits Will Save Progress and Restore Health and Stamina.";
                break;

            case 2:
                randomText = "Using Your Shield Will Block All Damage,But You Cannot Move While Casting It.";
                break;
            case 3:
                randomText = "Stamina Will Regenerate Over Time.";
                break;
        }

        gameObject.GetComponent<Text>().text = randomText;

    }
}
