using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float velocity = 0.1f;
    public KeyCode KeyUp = KeyCode.W;
    public KeyCode KeyDown = KeyCode.S;
    [SerializeField] private KeyCode KeyChangeColor = KeyCode.R;
    [SerializeField] private float force = 10f;
    [SerializeField] private Rigidbody2D rigidBody;
    
    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        PlayerChangeColor();
    }

    private void FixedUpdate()
    {
        PlayerMove(); 
    }
    private void PlayerMove()
    {
        // Move the player based on key inputs
        if (Input.GetKey(KeyUp))
        {
            rigidBody.AddForce(Vector3.up * force);
        }

        if (Input.GetKey(KeyDown))
        {
            rigidBody.AddForce(Vector3.down * force);
        }
    }

    private void PlayerChangeColor()
    {
        // Change Color on R key press
        if (Input.GetKeyUp(KeyChangeColor))
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            spriteRenderer.color = randomColor;
        }
    }

    
}
