using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("COLLISSION VARIABLES FOR DETECTION\n_______________________________________")]
    public float detectionSize = 1;
    [Range(1,0)]
    public float detectionTransparency = 0.15f;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.color -= new Color(0, 0, 0, detectionTransparency);
        Gizmos.DrawSphere(transform.position, detectionSize);
    }

    public void Awake()
    {
        
    }

}// end of PlayerInteract class
