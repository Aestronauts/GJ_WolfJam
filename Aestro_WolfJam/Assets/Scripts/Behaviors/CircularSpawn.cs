using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSpawn : MonoBehaviour
{
    public GameObject SFX_object;
    Vector3 spawnLoc;
    Vector2 spawnAdjustment;

    // Start is called before the first frame update
    void Start()
    {
        spawnLoc = gameObject.transform.position;
        spawnAdjustment = Random.insideUnitCircle * 7;
        spawnLoc = new Vector3(spawnLoc.x + spawnAdjustment.x, 0.5f, spawnLoc.z + spawnAdjustment.y);
        GameObject spawnedSFX_object = Instantiate(SFX_object, spawnLoc, Quaternion.identity);
        spawnedSFX_object.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
