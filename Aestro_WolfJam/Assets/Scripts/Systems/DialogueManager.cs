using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    float NoDialogueCounter = 0;

    //List<AK.Wwise.Event> WwiseDialogueEvents = new List<AK.Wwise.Event>();
    public AK.Wwise.Event levelStartTeachTutorial;
    public AK.Wwise.Event levelStartTutorial;
    public AK.Wwise.Event levelStart1;
    public AK.Wwise.Event levelStart2;
    public AK.Wwise.Event levelStart3;
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
        NoDialogueCounter += Time.deltaTime;
        if (NoDialogueCounter > 25)
        {
            PlayDialogue(2);
        }
    }

    /*
     * 1. Level Start                   Triggered
     * 2. Idle                          Triggered
     * 3. Player Checks Wrong Area      Triggered
     * 4. Player Doesn't Move           Triggered
     * 5. Player Escape                 Triggered
     * 6. Player Killed                 Triggered
     */

    public void PlayDialogue(int i)
    {
        NoDialogueCounter = 0;
        if (i == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1) //bI 1 is level -1
            {
                levelStartTeachTutorial.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2) //bI 2 is level 0
            {
                levelStartTutorial.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3) //bI 3 is level 1
            {
                levelStart1.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                levelStart2.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                levelStart3.Post(gameObject);
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
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                playerEscapes.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                playerEscapes.Post(gameObject);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {

            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {

            }
        }
        //add more under
    }
}
