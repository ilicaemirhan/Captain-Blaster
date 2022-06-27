using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//kütüphaneyi unutma

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //textmeshpro...
    public TextMeshProUGUI gameOverText;

    int playerScore = 0;

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }
    public void PlayerDied()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0; //Oyunu durdurur.
    }
}
