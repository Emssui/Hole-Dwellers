using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTriggerChange : MonoBehaviour
{
    public GameObject tutText;
    public GameObject faded;
    public Image fadeImage;
    public float fadeDuration = 1.0f; // Duration of the fade-out effect
    private bool playerInsideTrigger = false;

    void Start()
    {
        // Ensure that the fade image is initialized properly
        if (fadeImage != null)
        {
            fadeImage.color = Color.clear;
        }
    }

    void Update()
    {
        // Check if player is inside the trigger and presses the "E" key
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(FadeOutAndLoadNextScene());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            faded.SetActive(true);
            tutText.SetActive(true);
            playerInsideTrigger = true;
        }
    }

    IEnumerator FadeOutAndLoadNextScene()
    {
        // Start fading out
        float startTime = Time.time;
        Color initialColor = fadeImage.color;
        Color targetColor = Color.black;

        while (Time.time - startTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, (Time.time - startTime) / fadeDuration);
            fadeImage.color = Color.Lerp(initialColor, targetColor, alpha);
            yield return null;
        }

        // Load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
