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
    
    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        PlayerMove();
        PlayerChangeColor();
    }

    private void PlayerMove()
    {
        // Move the player based on key inputs
        if (Input.GetKey(KeyUp))
        {
            transform.position = transform.position + new Vector3(0, velocity, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyDown))
        {
            transform.position = transform.position + new Vector3(0, -velocity, 0) * Time.deltaTime;
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
