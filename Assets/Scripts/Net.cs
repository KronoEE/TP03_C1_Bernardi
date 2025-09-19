using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    public bool isPlayer01Goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isPlayer01Goal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player01Scored();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player02Scored();
            }
        }
    }
}
