using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float velocity = 50f;
    public KeyCode KeyUp = KeyCode.W;
    public KeyCode KeyLeft = KeyCode.A;
    public KeyCode KeyDown = KeyCode.S;
    public KeyCode KeyRight = KeyCode.D;

    public Vector3 startPos;
    [SerializeField] private Rigidbody2D rigidBody;


    void Start()
    {
        //Setting the start position of the player
        startPos = transform.position;

        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

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

            rigidBody.AddForce(Vector2.up * velocity);   
        }

        if (Input.GetKey(KeyDown))
        {

            rigidBody.AddForce(Vector2.down * velocity);
        }
        if (Input.GetKey(KeyLeft))
        {

            rigidBody.AddForce(Vector2.left * velocity);
        }

        if (Input.GetKey(KeyRight))
        {

            rigidBody.AddForce(Vector2.right * velocity);
        }

    }

    public void Reset()
    {
        rigidBody.velocity = Vector2.zero;
        transform.position = startPos;
    }
}
