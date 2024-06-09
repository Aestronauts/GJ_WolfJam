using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{

    public string nextLevelName;
    public float waitTime;

    public PlayerMovement playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // This method is called when the collider attached to this GameObject collides with another collider
    void OnTriggerEnter(Collider collision)
    {
        // // Log the name of the GameObject that this GameObject collided with
        // Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        //
        // // Optional: Check if the collision is with a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.enabled = false;
            DialogueManager.instance.PlayDialogue(5);
            StartCoroutine(WaitTime());
            // Do something if the collided GameObject has the specified tag
            //Debug.Log("Collided with a GameObject with tag 'YourTag'");
        }

        //SceneManager.LoadScene(nextLevelName);
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextLevelName);
    }
}
