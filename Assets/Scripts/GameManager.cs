using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GameOver() {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart() {
        Debug.Log("Game Over");

        // Wait a bit before restarting.
        yield return new WaitForSeconds(1f);

        // Restart scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        yield return null;
    }
}
