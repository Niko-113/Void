using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager master;
    public Text scoreText;
    public Text livesText;
    public Text endText;
    public Button endButton;
    public Button continueButton;

    public Player player;
    public EnemyManager enemyManager;

    private int score = 0;

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
        livesText.text = ("LIVES: " + player.hp);
        if (player.hp <= 0) StartCoroutine("GameOver");
    }

    IEnumerator GameOver()
    {
        while (Time.timeScale > 0)
        {
            Time.timeScale -= 0.01f;
            if (Time.timeScale < 0.1f)
            {
                endText.gameObject.SetActive(true);
                endButton.gameObject.SetActive(true);
                continueButton.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    public void ReturnToMenu()
    {
        StopCoroutine("GameOver");
        Time.timeScale = 1;
        SceneLoader.loader.Load("MenuScene");
    }

    public void Continue()
    {
        endText.gameObject.SetActive(false);
        endButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        StopCoroutine("GameOver");
        score = 0;
        AddPoints(0);
        player.enabled = true;
        player.Respawn();
        livesText.text = ("LIVES: " + 3);
        Time.timeScale = 1;
    }

    public void CheckForEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && enemyManager.finished) Victory();
    }

    void Victory()
    {
        endText.text = "        VICTORY\nFINAL SCORE: " + score.ToString("D4");
        endText.gameObject.SetActive(true);
        Time.timeScale = 0;
        endButton.gameObject.SetActive(true);
    }




}
