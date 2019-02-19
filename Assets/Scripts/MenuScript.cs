using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject mainPanelCreditsButton;
    public GameObject creditPanel;
    public GameObject creditsPanelBackButton;
    EventSystem m_EventSystem;

    public void Awake()
    {
        m_EventSystem = EventSystem.current;
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
        m_EventSystem.SetSelectedGameObject(creditsPanelBackButton);
    }

    public void MainMenu()
    {
        mainPanel.SetActive(true);
        creditPanel.SetActive(false);
        m_EventSystem.SetSelectedGameObject(mainPanelCreditsButton);
    }


}
