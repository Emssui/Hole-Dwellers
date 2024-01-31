using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;
    public void PlayGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 2) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void Options()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void Back()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}