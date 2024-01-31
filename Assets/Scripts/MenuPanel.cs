using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button myButton;

    private void Start()
    {
        // Disable the button initially
        myButton.gameObject.SetActive(false);
    }

   private void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape)) {            
            Time.timeScale = 0;
            // Toggle the visibility of the button
            myButton.gameObject.SetActive(!myButton.gameObject.activeSelf);
        } else if (!myButton.gameObject.activeSelf) {
            // Reset Time.timeScale to 1
            Time.timeScale = 1;
        }
    }

    // private void ShowMenu() {
    //     myButton.gameObject.SetActive(!myButton.gameObject.activeSelf);
    // }

     public void QuitGame()
    {
        Application.Quit();
    }
}
