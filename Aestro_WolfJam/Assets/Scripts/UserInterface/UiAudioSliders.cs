using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAudioSliders : MonoBehaviour
{
    public Slider masterVolumeSlider, sfxVolumeSlider, atmosphereVolumeSlider, dialogueVolumeSlider;


    // Start is called before the first frame update
    void Awake()
    {
        UpdateSliderVolumes();
    }


    public void UpdateSliderVolumes()
    {
        if(masterVolumeSlider)
            AkSoundEngine.SetRTPCValue("MasterVolume", masterVolumeSlider.value);
        if(sfxVolumeSlider)
            AkSoundEngine.SetRTPCValue("SFXVolume", sfxVolumeSlider.value);
        if(atmosphereVolumeSlider)
            AkSoundEngine.SetRTPCValue("AtmosphereVolume", sfxVolumeSlider.value);
        if(dialogueVolumeSlider)
            AkSoundEngine.SetRTPCValue("DialogueVolume", sfxVolumeSlider.value);
    }


}// end of UiAudioSliders class
