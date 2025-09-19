using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("WinScreen")]
    public GameObject winScreen;
    public TextMeshProUGUI winText;

    [Header("Ball")]
    public GameObject ball;

    [Header("Player01")]
    public GameObject player01Paddle;
    public GameObject player01Goal;

    [Header("Player02")]
    public GameObject player02Paddle;
    public GameObject player02Goal;


    [Header("ScoreUI")]
    public GameObject player01Text;
    public GameObject player02Text;

    private int player01Score = 0;
    private int player02Score = 0;

    public void Player01Scored()
    {
        player01Score++;
        player01Text.GetComponent<TextMeshProUGUI>().text = player01Score.ToString();
        ResetPositions();
        CheckGoals();
    }
    public void Player02Scored()
    {
        player02Score++;
        player02Text.GetComponent<TextMeshProUGUI>().text = player02Score.ToString();
        ResetPositions();
        CheckGoals();
    }

    private void ResetPositions()
    {
        ball.GetComponent<Ball>().Reset();
        player01Paddle.GetComponent<PlayerMovement>().Reset();
        player02Paddle.GetComponent<PlayerMovement>().Reset();
    }


    private void CheckGoals()
    {
        if (player01Score >= 5 || player02Score >= 5)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);

        if (player01Score >= 5)
        {
            winText.text = "Player 1 Wins!";
        }
        
        if (player02Score >= 5)
        {
            winText.text = "Player 2 Wins!";
        }
    }
}
