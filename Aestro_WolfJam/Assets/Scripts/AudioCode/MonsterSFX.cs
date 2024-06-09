using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSFX : MonoBehaviour
{
    public float radius = 10f;
    public GameObject monster;

    PlayerMovement _playerMovement;

    public float minSpawnInterval;
    public float maxSpawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GameObject.Find("PlayerSample").GetComponent<PlayerMovement>();
        if (_playerMovement == null) Debug.LogWarning("Player Movement is Null - MonsterSFX");

        StartCoroutine(MonsterSpawnCycle());  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) == true)
        {
            Debug.Log("M pressed...");
            SpawnMonster();
        }
    }

    private void SpawnMonster()
    {
        Transform spawnLocation = gameObject.transform;
        //Debug.Log("x: " + spawnLocation.transform.position.x);
        //Debug.Log("y: " + spawnLocation.transform.position.y);
        //Debug.Log("z: " + spawnLocation.transform.position.z);

        float x = Random.Range(-10f, 10f);
        Debug.Log("randomized x: " + x);

        float radius_squared = radius * radius;
        float x_squared = x * x;
        float y = radius_squared - x_squared;
        y = Mathf.Sqrt(y);
        Debug.Log("calculated y: " + y);

        float posneg = Random.Range(-1f, 1f);
        Debug.Log("Random value for positive or negative: " + posneg);
        if (posneg <= 0) y = -y;

        Vector3 spawnLoc = new Vector3(spawnLocation.transform.position.x + x,
            spawnLocation.transform.position.y,
            spawnLocation.transform.position.z + y);

        Debug.Log("SpawnLoc x: " + spawnLoc.x);
        Debug.Log("SpawnLoc y: " + spawnLoc.y);
        Debug.Log("SpawnLoc z: " + spawnLoc.z);

        GameObject newMonster = Instantiate(monster, spawnLoc, transform.rotation);
        newMonster.SetActive(true);
    }

    IEnumerator MonsterSpawnCycle()
    {
        while (true)
        {
            Debug.Log("Monster Spawn Cycle activated");
            SpawnMonster();

            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
