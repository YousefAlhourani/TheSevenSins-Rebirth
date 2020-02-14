using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuController : MonoBehaviour
{
    public List<Button> PauseMenuButtons = new List<Button>();
    public GameObject PauseMenu;
    public GameObject SettingsPanel;
    public GameObject InventoryPanel;
    private bool IsPaused { get; set; }
    InventoryUI InventoryItems;

    //Loading Screen Related STuff
    public GameObject loadingScreen;
    [SerializeField] Image loadingSlider;
    private bool loadingDelay = false;
    public GameObject HUD;

    private void Awake()
    {
        HUD.SetActive(true);
        PauseMenu.SetActive(false);
        SettingsPanel.SetActive(false);
        InventoryPanel.SetActive(false);
        IsPaused = false;
        InventoryItems = GetComponent<InventoryUI>();
         
    }

    private void Update()
    {
        if(Input.GetButtonDown("Start")&&!IsPaused)
        {
            OpenPauseMenu();
        }
        if(Input.GetButtonDown("B Button")&&IsPaused)
        {
            ClosePauseMenu();
        }

        if(loadingDelay)
        {
            loadingSlider.fillAmount += 0.02f;
            if (loadingSlider.fillAmount == 1)
            {
                StartCoroutine(LoadScreen());
            }
        }

    }


    public void InventoryOpen()
    {

        if (InventoryPanel.GetComponentInChildren<Button>() != null)
        {
            EventSystem.current.SetSelectedGameObject(InventoryPanel.GetComponentInChildren<Button>().gameObject, new BaseEventData(EventSystem.current));
        }
        PauseMenu.SetActive(false);
        SettingsPanel.SetActive(false);
        InventoryPanel.SetActive(true);
    }

    public void SettingsOpen()
    {
        PauseMenu.SetActive(false);
        SettingsPanel.SetActive(true);
        InventoryPanel.SetActive(false);
    }

    void OpenPauseMenu()
    {
        IsPaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(PauseMenuButtons[0].gameObject);
    }

    public void ClosePauseMenu()
    {
        IsPaused = false;
        PauseMenu.SetActive(false);
        InventoryPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitToMainMenu()
    {
        GameEvents.OnSaveInitiated();
        PauseMenu.SetActive(false);
        InventoryPanel.SetActive(false);
        HUD.SetActive(false);
        loadingDelay = true;
        loadingScreen.SetActive(true);
          
    }

    public void QuitToMainMenuWrathsNest()
    {
        PauseMenu.SetActive(false);
        InventoryPanel.SetActive(false);
        HUD.SetActive(false);
        loadingDelay = true;
        loadingScreen.SetActive(true);

    }

    IEnumerator LoadScreen()
    {

        loadingDelay = false;
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            yield return null;

        }

    }
}
