using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    //public GameObject layoutHUD;
    Button selectedButton;
    private void Start()
    {
        
        //layoutHUD.SetActive(false);
        selectedButton= gameObject.transform.Find("GameOverPanel").Find("Restart").GetComponent<Button>();
        selectedButton.Select();
        Time.timeScale = 0;
       
        GabrielsSystemManager.gabie.PauseCharacter();
    }
    public void ReturnToMainMenu()
   {
        SceneManager.LoadScene(0);
   }

    public void RestartLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            Scene x = SceneManager.GetActiveScene();
            SceneManager.LoadScene(x.buildIndex);
        }
    }

}
