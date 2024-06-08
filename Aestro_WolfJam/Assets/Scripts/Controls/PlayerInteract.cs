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

        if (trig.name == "CellphoneSound")
            print("can press SPACE key to stop the cellphone");

        if (trig.name == "CellphoneSound" && Input.GetKeyDown(KeyCode.Space))
        {
            print($"TURNING OFF OBJ: {trig.name}");
            trig.gameObject.SetActive(false);
        }
    }
}// end of PlayerInteract class
