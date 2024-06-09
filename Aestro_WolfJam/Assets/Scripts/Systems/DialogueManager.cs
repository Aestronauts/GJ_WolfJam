using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    float NoDialogueCounter = 0;

    //List<AK.Wwise.Event> WwiseDialogueEvents = new List<AK.Wwise.Event>();
    public AK.Wwise.Event levelStartTutorial;
    public AK.Wwise.Event levelStart1;
    public AK.Wwise.Event checksWrongArea;
    public AK.Wwise.Event playerDoesntMove;
    public AK.Wwise.Event playerEscapes;
    public AK.Wwise.Event playerKilled;
    public AK.Wwise.Event playerIdles;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void Update()
    {
        
    }

    /*
     * 1. Level Start                   Triggered
     * 2. Idle
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
                levelStartTutorial.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1) // scene id needs to be set up but this should be level 1
            {
                levelStart1.Post(gameObject);
            }
        }
        else if (i == 2)
        {
            playerIdles.Post(gameObject);
        }
        else if (i == 3)
        {
            checksWrongArea.Post(gameObject);
        }
        else if (i == 4)
        {
            playerDoesntMove.Post(gameObject);
        }
        else if (i == 5)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) // scene id needs to be set up but this should be level 0
            {
                playerEscapes.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1) // scene id needs to be set up but this should be level 1
            {
                playerEscapes.Post(gameObject);
            }
        }
        //add more under
    }
}
