using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
  private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Getting sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Change color to black when colliding with a wall
            spriteRenderer.color = Color.black;
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            // Change to a random color when colliding with the ball
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}

