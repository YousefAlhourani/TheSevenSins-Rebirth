using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public GameObject loadingScreen;
    [SerializeField] Image loadingSlider;
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public AudioSource backMusic;
    bool notMainMenu = false;
    public GameObject continueGame;
    public GameObject newGame;
    private bool loadingDelay=false;

    int sceneIndex;
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        backMusic.volume = 0.5f;
        if (SaveLoadSystem.SaveExists("Inventory") || SaveLoadSystem.SaveExists("CollectedItems"))
        {
            continueGame.SetActive(true);
            EventSystem.current.SetSelectedGameObject(continueGame);
        }
        else
        {
            continueGame.SetActive(false);
            newGame.GetComponent<Button>().Select();
            EventSystem.current.SetSelectedGameObject(newGame);
        }
        Time.timeScale = 1;
    }

    public void ContinueGame(int index)
    {
        loadingScreen.SetActive(true);
        mainMenuPanel.SetActive(false);
        loadingDelay = true;
        index= PlayerPrefs.GetInt("SceneCheckPoint",1);
        sceneIndex = index;
        backMusic.volume = 0f;
    }

    public void NewGame(int index)
    {
        if (SaveLoadSystem.SaveExists("Inventory") || SaveLoadSystem.SaveExists("CollectedItems"))
        {
            SaveLoadSystem.DeleteAllSavedFiles();
        }
        PlayerPrefs.DeleteAll();
        
        loadingScreen.SetActive(true);
        mainMenuPanel.SetActive(false);
        loadingDelay=true;
        sceneIndex=index;
        continueGame.SetActive(false);
        backMusic.volume = 0f;
    }

    public void CreditScene()
    {
        SceneManager.LoadScene(5);
    }
    IEnumerator LoadScreen(int index)
    {
        
        loadingDelay =false;
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return null;

        }
        
    }

    public void SettingsMenu()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        
       
        
    }










    private void Update()
    {
        if (Input.GetButtonDown("B Button")&&settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            mainMenuPanel.GetComponentInChildren<Button>().Select();
        }
        if(loadingDelay)
        {
            loadingSlider.fillAmount+=0.02f;
            if(loadingSlider.fillAmount==1)
            {
               StartCoroutine(LoadScreen(sceneIndex));
            }
        }
    } 
}
