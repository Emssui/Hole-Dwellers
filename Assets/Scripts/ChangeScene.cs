using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController : MonoBehaviour
{
    public float sceneChangeTime = 40f; // Time in seconds before scene change

    private float elapsedTime = 0f;

    void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time has reached the desired scene change time
        if (elapsedTime >= sceneChangeTime)
        {
            // Call a method to change the scene or load a new scene
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        // Change the scene using SceneManager
        // You can replace "YourSceneName" with the actual name of the scene you want to load
        SceneManager.LoadScene("Act1");
    }
}
