using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public static System.Action SaveInitiated;

    public GameObject Player;
    public CheckPointManager managerCheckPoints;

    private void Awake()
    {
        Time.timeScale = 1;

        if(SceneManager.GetActiveScene().buildIndex==1)
                {
                   Instantiate(Player, managerCheckPoints.CheckPoints[PlayerPrefs.GetInt("Level1CheckPoint", 0)].position,Quaternion.identity );
                }
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                {

                 Instantiate(Player, managerCheckPoints.CheckPoints [PlayerPrefs.GetInt("Level2CheckPoint", 0)].position, Quaternion.identity);
            
                } 
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    Instantiate(Player, managerCheckPoints.CheckPoints[PlayerPrefs.GetInt("Level3CheckPoint", 0)].position, Quaternion.identity);
                }
    
        
    }


    public static void OnSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }
    
  

  

    
  
}
