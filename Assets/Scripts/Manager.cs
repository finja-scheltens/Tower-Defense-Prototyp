using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int lives = 5;
    public TMP_Text gameOverText;
    
    public void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void LoseLife(int l = 1)
    {
        lives -= l;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    { 
        gameOverText.text = "Game over";
        gameOverText.gameObject.SetActive(true);
    }
}
