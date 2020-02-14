using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{

    public int CheckPointIndex;
    public GameObject AutoSavePopUp;
    public GameObject PressToSave;
    public bool isActiveCheckPoint = true;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            PressToSave.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
           
            if(Input.GetButtonDown("A Button"))
            {
                if(SceneManager.GetActiveScene().buildIndex==1)
                {
                    PlayerPrefs.SetInt("Level1CheckPoint",CheckPointIndex);
                }
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    PlayerPrefs.SetInt("Level2CheckPoint", CheckPointIndex);
                } 
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PlayerPrefs.SetInt("Level3CheckPoint", CheckPointIndex);
                }

                if(Input.GetButtonDown("A Button"))
                {
                    GabrielsSystemManager.gabie.Health = 100f;
                    GabrielsSystemManager.gabie.staminaCost = 100f;
                    AutoSavePopUp.SetActive(true);
                    PressToSave.SetActive(false);
                    Invoke("TurnOffUI", 2f);
                }
                GameEvents.OnSaveInitiated();
                this.gameObject.GetComponent<Collider>().enabled = false;
                Debug.Log("Saved");
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            PressToSave.SetActive(false);
        }
    }

    void TurnOffUI()
    {
        AutoSavePopUp.SetActive(false);
    }
}
