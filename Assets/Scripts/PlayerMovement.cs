using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float velocity = 0.1f;
    public float angleRotation = 10f;
    public KeyCode KeyUp = KeyCode.W;
    public KeyCode KeyDown = KeyCode.S;
    public KeyCode KeyRight = KeyCode.D;
    public KeyCode KeyLeft = KeyCode.A;
    
    [SerializeField] private KeyCode KeyChangeColor = KeyCode.R;
    
    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        PlayerMove();
        PlayerRotation();
        PlayerChangeColor();
    }

    private void PlayerMove()
    {
        // Move the player based on key inputs
        if (Input.GetKey(KeyUp))
        {
            transform.position = transform.position + new Vector3(0, velocity, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyLeft))
        {
            transform.position = transform.position + new Vector3(-velocity, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyDown))
        {
            transform.position = transform.position + new Vector3(0, -velocity, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyRight))
        {
            transform.position = transform.position + new Vector3(velocity, 0, 0) * Time.deltaTime;
        }

    }

    private void PlayerRotation()
    {
        // 10° rotation on Q key press (Left rotation)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f, 0f, angleRotation));
        }
        // -10° rotation on E key press (Right rotation)
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f, 0f, -angleRotation));
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
