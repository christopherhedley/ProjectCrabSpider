using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject creditPanel;

    public void Awake()
    {
        mainPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void StartGame()
    {
        Debug.Log("Starting Game...");
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

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Application...");
    }

    public void CreditsMenu()
    {
        mainPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void MainMenu()
    {
        mainPanel.SetActive(true);
        creditPanel.SetActive(false);
    }


}
