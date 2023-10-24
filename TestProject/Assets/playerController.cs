using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class playerController : MonoBehaviour
{
    private float horizontal;
    private float horSpeed = 8.0f;
    private float jumpSpeed = 15.0f;
    public GameObject platform; 
    public float minSpawnInterval = 0.01f; 
    public float maxSpawnInterval = 0.5f;
    public float minSpawnPosition = -5.0f;
    public float maxSpawnPosition = 5.0f;
    public double nextSpawnTime;
    public Vector3 spawnPosition;
    public int score = 0;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * horSpeed, rb.velocity.y);
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
    }
}