using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField]int sceneIndex;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image loadingSlider;

    [SerializeField] GameObject popUptext;

    [SerializeField] GameObject HUDLayout;

    
   private bool loadingDelay=false;


    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Portal(sceneIndex);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            popUptext.SetActive(false);
        }
    }

    void Portal(int index)
    {
       
        
        popUptext.SetActive(true);

        
        if (Input.GetButtonDown("A Button"))
        {
            GameEvents.OnSaveInitiated();
            popUptext.SetActive(false);
            HUDLayout.SetActive(false);
            Time.timeScale = 0f;
            loadingScreen.SetActive(true);
            loadingDelay=true;
            
            
        }

    }

    IEnumerator LoadScreen(int sceneIndex)
    {
        loadingDelay=false;
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4) { PlayerPrefs.SetInt("SceneCheckPoint", 3); }
        else { PlayerPrefs.SetInt("SceneCheckPoint", sceneIndex); }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
           
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.fillAmount += progress;
            
            yield return null;

        } 
    }
    void Update()
    {
        if(loadingDelay)
        {
            //loadingSlider.fillAmount+=0.02f;
            //if(loadingSlider.fillAmount==1)
            //{
                
                StartCoroutine(LoadScreen(sceneIndex));

           // }
        }
    }
   


  
  
}
