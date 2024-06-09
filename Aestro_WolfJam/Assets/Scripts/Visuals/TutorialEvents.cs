using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{

    public List<Light> spotlights = new List<Light>();



    public IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(0);
    }

    public IEnumerator LowerAWall(GameObject objectToLower)
    {
        yield return new WaitForSeconds(0);
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
