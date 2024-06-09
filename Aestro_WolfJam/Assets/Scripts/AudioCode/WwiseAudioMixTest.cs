using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseAudioMixTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            int randomVolume = Random.Range(0, 100);
            Debug.Log("Random Volume Value: " + randomVolume);
            AkSoundEngine.SetRTPCValue("MasterVolume", randomVolume);
        }
    }
}
