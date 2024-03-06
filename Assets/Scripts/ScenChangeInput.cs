using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInput : MonoBehaviour
{
    // Update is called once per frame
    public GameObject EnterCanvas;
    private float canvasVis = 0;
    void Update()
    {
        // Check if the Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            canvasVis++;
            EnterCanvas.SetActive(true);

            if (canvasVis >= 2 && Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                // Load the desired scene
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

                int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
