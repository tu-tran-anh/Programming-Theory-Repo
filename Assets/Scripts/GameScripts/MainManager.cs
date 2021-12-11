using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timer;

    private float time = 30;
    private int currentScore = 0;
    private string playerName= "";
    private GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel = transform.GetChild(1).gameObject;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.Instance.gameOver)
        {
            gameOverPanel.SetActive(true);
            MenuManager.Instance.SaveBestPlay();
        }
        else
        {
            time -= Time.deltaTime;
            timer.text = $"Time : {Mathf.RoundToInt(time)}";
            if (time <= 0) MenuManager.Instance.gameOver = true;

            currentScore = MenuManager.Instance.currentScore;
            playerName = MenuManager.Instance.playerName;
            if (currentScore > MenuManager.Instance.bestScore)
            {
                MenuManager.Instance.bestScore = currentScore;
                MenuManager.Instance.bestName = playerName;
            }
            DisplayScores();
        }
    }
    void DisplayScores()
    {
        scoreText.text = $"Score : {playerName} {currentScore}";
    }
    public void OnClickReturn()
    {
        ResetGame();
        SceneManager.LoadScene(0);
    }

    public void OnClickRestart()
    {
        ResetGame();
        SceneManager.LoadScene(1);
    }
    void ResetGame()
    {
        MenuManager.Instance.currentScore = 0;
        MenuManager.Instance.gameOver = false;
    }
}
