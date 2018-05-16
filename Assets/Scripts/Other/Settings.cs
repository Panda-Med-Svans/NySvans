using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public AudioMixer audioMixer;


    
    #region Volume Settings

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        //Debug.Log(volume);
    }
    public void SetAmbienceVolume(float volume)
    {
        audioMixer.SetFloat("ambienceVolume", volume);
        //Debug.Log(volume);
    }
    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("effectVolume", volume);
        //Debug.Log(volume);
    }

    #endregion

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("Quality set to" + qualityIndex);
    }




}
