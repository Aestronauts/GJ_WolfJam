using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("COLLISSION VARIABLES FOR DETECTION\n_______________________________________")]
    public float detectionSize = 1;
    [Range(1,0)]
    public float detectionTransparency = 0.15f;
    public SphereCollider colSphere;
    public string objectNameDetection = "Key Object";
    public AK.Wwise.Event turnoffKeyObject;
    public AK.Wwise.Event activateExit;
    private bool isExitActivated = false;

    public GameObject exit_gameObject;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.color -= new Color(0, 0, 0, detectionTransparency);
        Gizmos.DrawSphere(transform.position, detectionSize);
    }

    public void Update()
    {
        colSphere.radius = detectionSize;
    }


    public void OnTriggerStay(Collider trig)
    {
        print($"trig: {trig.name}");

        if (trig.name == objectNameDetection)
            print($"can press SPACE key to stop the {objectNameDetection}");

        if (trig.name == objectNameDetection && Input.GetKey(KeyCode.Space))
        {
            print($"TURNING OFF OBJ: {trig.name}");
            //trig.gameObject.SetActive(false);
            turnoffKeyObject.Post(trig.gameObject);
            if (isExitActivated == false)
            {
                activateExit.Post(exit_gameObject);
                isExitActivated = true;
            }
        }
    }
}// end of PlayerInteract class
