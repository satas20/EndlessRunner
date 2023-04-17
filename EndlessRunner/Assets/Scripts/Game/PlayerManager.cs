using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject startGameText;

    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text scoreText;


    public static bool gameOver;
    public static bool gameStarted;

    public static int coinCount;
    public static float timeCount;

    void Start()
    {
        gameStarted = false;
        timeCount = 0;
        coinCount = 0;
        Time.timeScale = 1;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeManager.tap){
            gameStarted = true;
            Destroy(startGameText);
        }
        if (gameStarted&&!gameOver) { timeCount += (Time.deltaTime); }
        

        timeText.text =  (timeCount).ToString("0");
        coinText.text = coinCount.ToString();
        scoreText.text =  "Your Score : " +  (timeCount+ coinCount*10).ToString("0");
        if (gameOver)
        {

            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
    
}
