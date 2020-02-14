using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    AudioMixer masterVolume; //controls volume of game
    Resolution[] resolutions; //array of resolutions
    [SerializeField]
    Dropdown resolutionDropDown;

    void Start()
    {
        resolutions=Screen.resolutions;//gets all resolutions from PC

        resolutionDropDown.ClearOptions(); //so no weird resolutions show up

        List<string> resolutionNames = new List<string>(); //we need to convert to string since array is of indexes

        int currentResolutionIndex = 0; //the default resolution of PC

        for (int i = 0; i < resolutions.Length; i++) //converts everything to string and chooses default index
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionNames.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(resolutionNames);//we add them to the drop down list
        resolutionDropDown.value = currentResolutionIndex; //we make sure the defualt resolution is the first selected
        resolutionDropDown.RefreshShownValue(); //to force the resolutions to show up.
        
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution setResolution = resolutions[resolutionIndex];
        Screen.SetResolution(setResolution.width,setResolution.height,Screen.fullScreen);
        
        
      
    }


    public void SetVolume(float volume)
    {
        masterVolume.SetFloat("MasterVolume", volume);
    }



    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }

   
}
