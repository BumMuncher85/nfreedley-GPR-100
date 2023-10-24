using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour
{
    public float minSpawnInterval = 0.01f;
    public float maxSpawnInterval = 0.5f;
    public float minSpawnPosition = -5.0f;
    public float maxSpawnPosition = 5.0f;
    public Vector3 spawnPosition;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPlatform", 0f, 1.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPlatform()
    {
        spawnPosition = new Vector3(Random.Range(minSpawnPosition, maxSpawnPosition), 5.5f, 0f);

        Instantiate(platform, spawnPosition, Quaternion.identity);
    }
}
