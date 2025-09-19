using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidBody;
    public Vector3 startPos;

    [Header("Speed Increase Settings")]
    public float speedIncreaseRate = 0.5f; 
    public float increaseInterval = 5f;    
    private float timer;

    void Start()
    {
        startPos = transform.position;
        AddForce();
        timer = increaseInterval;
    }

    void Update()
    {
        // Timer to increase speed at intervals
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            IncreaseSpeed();
            timer = increaseInterval; 
        }
    }

    private void AddForce()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rigidBody.velocity = new Vector2(speed * x, speed * y);
    }

    private void IncreaseSpeed()
    {
        speed += speedIncreaseRate;

        Vector2 direction = rigidBody.velocity.normalized;
        rigidBody.velocity = direction * speed;
    }

    public void Reset()
    {
        rigidBody.velocity = Vector2.zero;
        transform.position = startPos;
        speed = 5f; 
        AddForce();
        timer = increaseInterval;
    }
}

