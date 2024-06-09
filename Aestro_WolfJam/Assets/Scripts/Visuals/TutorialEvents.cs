using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{

    public List<Light> spotlights = new List<Light>();


    public void Awake()
    {
        StartCoroutine(TutorialScript());
    }

    public IEnumerator TutorialScript()
    {
        // wait a moment for player to load and understand
        yield return new WaitForSeconds(5);

        // play first voice line
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
