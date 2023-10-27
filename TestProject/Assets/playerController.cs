using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class playerController : MonoBehaviour
{
    private float horizontal;
    private float horSpeed = 8.0f;
    private float jumpSpeed = 15.0f;
    [SerializeField] public Transform tf;
    public GameObject platform;
 
    public float minSpawnInterval = 0.01f; 
    public float maxSpawnInterval = 0.5f;
    public float minSpawnPosition = -5.0f;
    public float maxSpawnPosition = 5.0f;
    public double nextSpawnTime;
    public Vector3 spawnPosition;

    public int score = 0;

    public bool restarted = false;

    [SerializeField] float startTime;
    bool timerStarted = false;
    float currentTime;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Button restartButton;
    [SerializeField] private Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        timerStarted = true;
        restartButton.onClick.AddListener(onRestart);
    }

    // Update is called once per frame
    void Update()
    {
        if ((tf.position.y < -5) || currentTime == 0)
        {
            timerStarted = false;
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            if (timerStarted == true)
            {
                currentTime -= Time.deltaTime;
            }
            if (currentTime < 0)
            {
                timerStarted = false;
                currentTime = 0;
            }       
        }
        timerText.text = "Timer: " + Math.Round(currentTime).ToString();
    }

    void onRestart()
    {
        Debug.Log("Hit restart");
        tf.position = new Vector3(0, 1, 0);
        Instantiate(platform, new Vector3(-4, 2, 0), Quaternion.identity);
        Instantiate(platform, new Vector3(0, -1, 0), Quaternion.identity);
        Instantiate(platform, new Vector3(3, 1, 0), Quaternion.identity);
        score = 0;
        currentTime = startTime;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * horSpeed, rb.velocity.y);
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            if (rb.velocity.y < 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                score += 50;
                scoreText.text = "Score: " + score.ToString();
                restarted = true;
            }
        }
    }
}