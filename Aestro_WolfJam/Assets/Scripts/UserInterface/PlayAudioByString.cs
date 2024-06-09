using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioByString : MonoBehaviour
{
    public bool useTextToSpeech = true;

    public void ToggleUseTextToSpeech()
    {
        useTextToSpeech = !useTextToSpeech;
    }

    public void PlayWwisByString(string eventName)
    {
        if(useTextToSpeech)
            AkSoundEngine.PostEvent(eventName, gameObject);
    }
}
