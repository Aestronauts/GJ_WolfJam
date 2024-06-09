using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    /*
     * 1. Level Start                   Triggered
     * 2. 
     * 3. Player Checks Wrong Area
     * 4. Player Doesn't Move           Triggered
     * 5. Player Escape
     * 6. Player Killed                 Triggered
     */

    public void PlayDialogue(int i)
    {
        if (i == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) // scene id needs to be set up but this should be level 0
            {

            }
            else if (SceneManager.GetActiveScene().buildIndex == 1) // scene id needs to be set up but this should be level 1
            {

            }
        }
        else if (i == 2)
        {

        }
        //add more under
    }
}
