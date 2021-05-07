using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager master;
    public Text scoreText;
    public Text livesText;

    private int score = 0;
    public int lives = 3;

    void Start()
    {
        master = this;
        AddPoints(0);
    }


    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = ("SCORE: " + score.ToString("D4"));
    }

    public void PlayerHurt()
    {
        lives--;
        livesText.text = ("LIVES: " + lives);
        if (lives <= 0) GameOver();
    }

    private void GameOver(){

    }




}
