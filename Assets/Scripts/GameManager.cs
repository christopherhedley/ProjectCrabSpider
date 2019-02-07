using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool paused;
    public Text gameTimerText;
    public Text gameOverText;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public float gameTimer = 60f;
    private bool gameOver = false;

    void Awake()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !paused)
            {
                Pause();
            }
            else if (Input.GetKeyUp(KeyCode.Escape) && paused)
            {
                unPause();
            }
        }

        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }
        else if (!gameOver)
        {
            gameOverText.text = "You ran out of time!";
            GameOver();
            gameOver = true;
            Debug.Log("GAME OVER: YOU RAN OUT OF TIME");
        }
    }

    void FixedUpdate()
    {
        gameTimerText.text = Mathf.Round(gameTimer).ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        pausePanel.SetActive(true);
        Debug.Log("paused");
    }

    public void unPause()
    {
        Time.timeScale = 1;
        paused = false;
        pausePanel.SetActive(false);
        Debug.Log("unpaused");
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_0");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Application...");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
