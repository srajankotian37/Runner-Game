using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    public GameObject tapToPlayText;

    void Start()
    {
        tapToPlayText.SetActive(true); // Show the "Press Space to Play" text
        Time.timeScale = 0f; // Pause the game
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Detect space key press
        {
            tapToPlayText.SetActive(false); // Hide the "Press Space to Play" text
            StartGame(); // Start the game
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f; // Resume the game
        Debug.Log("Game Started");
    }
}
