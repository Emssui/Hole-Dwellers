using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTriggerChange : MonoBehaviour
{
    public GameObject TutText;
    private bool playerInsideTrigger = false;

    void Update()
    {
        // Check if player is inside the trigger and presses the "E" key
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            LoadNextScene();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TutText.SetActive(true);
            playerInsideTrigger = true;
        }
    }

    void LoadNextScene()
    {
        // Get the current scene build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by incrementing the current scene build index
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
