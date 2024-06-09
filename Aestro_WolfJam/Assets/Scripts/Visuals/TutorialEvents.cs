using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TutorialEvents : MonoBehaviour
{

    public List<Light> spotlights = new List<Light>();

    public int clipID = 0;
    public List<AudioClip> tutorialClips = new List<AudioClip>();


    public void Awake()
    {
        StartCoroutine(TutorialScript(5));
    }

    public IEnumerator TutorialScript(float waitTime) // ------ CALL THIS TO PLAY THE NEXT LINE
    {
        // wait a moment for player to load and understand
        yield return new WaitForSeconds(waitTime);

        // play the voice line
        //AkSoundEngine.PostEvent(tutorialClips[clipID].name, gameObject);

        clipID++;

        ///sample
        // if clip == 0
            // wait 5 seconds for voice line
            // lower the wall that blocks us
    }

    public IEnumerator LowerAWall(GameObject objectToLower)
    {
        if (objectToLower)
        {
            for (int i = 0; i < 100; i++)
            {
                objectToLower.transform.position -= new Vector3(0, 0.25f, 0);
                yield return new WaitForSeconds(0.05f);
            }
        }      
    }

    public IEnumerator TurnDownLightIntensity()
    {
        if (spotlights.Count > 0)
        {
            foreach(Light spot in spotlights)
            {
                spot.intensity -= 1;
                yield return new WaitForSeconds(0.05f);
            }

            if (spotlights[0].intensity > 0)
                StartCoroutine(TurnDownLightIntensity());
        }
        
    }

}// end of TutorialEvents class
