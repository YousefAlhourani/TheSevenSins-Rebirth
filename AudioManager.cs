using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource[] AudioSources;
    public float audioVolumeFade = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySong(int songIndex) { AudioSources[songIndex].Play(); }
    public void StopSong(int songIndex) { AudioSources[songIndex].Stop(); }

    public void PlaySoundEffect(int songIndex) { AudioSources[songIndex].Play(); }
    public void TurnOffSoundEffect(int songIndex) { AudioSources[songIndex].Stop(); }

    public void PlaySong(int songindex,float maxVolume)
    {
        StartCoroutine(FadeIn(songindex,maxVolume));
    }

    public void ChangeSong(int songIndex, float transitionSpeed)
    {
        
        StartCoroutine(FadeOut(songIndex, transitionSpeed));
    }



    IEnumerator FadeIn(int SongIndex, float maxVolume)
    {
        AudioSources[SongIndex].Play();
        audioVolumeFade = AudioSources[SongIndex].volume;
        while (AudioSources[SongIndex].volume < maxVolume)
        {
            audioVolumeFade += 0.01f;
            AudioSources[SongIndex].volume = audioVolumeFade;
            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator FadeOut(int SongIndex, float transitionSpeed)
    {
        audioVolumeFade = AudioSources[SongIndex].volume;
        while (AudioSources[SongIndex].volume >0f)
        {
            audioVolumeFade -= transitionSpeed;
            AudioSources[SongIndex].volume = audioVolumeFade;
            yield return new WaitForSeconds(0.1f);

        }
    }
}
