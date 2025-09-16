using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float velocity = 0.1f;
    public KeyCode KeyUp = KeyCode.W;
    public KeyCode KeyDown = KeyCode.S;

    public Vector3 startPos;
    [SerializeField] private KeyCode KeyChangeColor = KeyCode.R;
    [SerializeField] private float force = 10f;
    [SerializeField] private Rigidbody2D rigidBody;
    
    
    void Start()
    {
        //Setting the start position of the player
        startPos = transform.position;

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
            rigidBody.AddForce(Vector2.up * force);
        }

        if (Input.GetKey(KeyDown))
        {
            rigidBody.AddForce(Vector2.down * force);
        }
    }

    public void Reset()
    {
        rigidBody.velocity = Vector2.zero;
        transform.position = startPos;
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
