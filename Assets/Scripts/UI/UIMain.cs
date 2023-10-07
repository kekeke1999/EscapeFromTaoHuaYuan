using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    public Text ui_time; // The UI text element for displaying time.
    public GameObject ui_over; // The game over UI panel.
    public GameObject ui_pause; // The pause UI panel.
    public Text ui_health; // The UI text element for displaying health value.
    public Text ui_coin; // The UI text element for displaying coins.
    public Text ui_prop; // The UI text element for displaying prop.

    private float countdownTime = 60f; // Initial time for the countdown timer.

    private void Awake()
    {
        Time.timeScale = 1.0f; // Set the time scale to 1 to ensure normal game speed.
    }

    private void Start()
    {
        UpdateTimerText(); // Initialize the timer text.
        ui_pause.GetComponent<Button>().onClick.AddListener(Gamepause); // Set a button click listener for the pause button.
    }

    private void Update()
    {
        countdownTime -= Time.deltaTime; // Decrease the remaining time in each frame.

        if (countdownTime <= 0)
        {
            countdownTime = 0;
            // Time is up, the game will end automatically.
            Gameover("Congratulations, You win!");
        }

        if (ui_health.text == "0")
        {
            // If health value becomes zero, the game ends.
            Gameover("Game Over.");
        }

        UpdateTimerText(); // Update the timer text display.
    }

    // Update the timer text on the UI.
    void UpdateTimerText()
    {
        ui_time.text = "00: " + countdownTime.ToString("F2"); // Display time with two decimal places.
    }

    // Game over logic.
    private void Gameover(string text)
    {
        ui_over.transform.GetChild(0).GetComponent<Text>().text = text; // Set the game over text.
        ui_over.SetActive(true); // Activate the game over UI panel.
        ui_pause.GetComponent<Button>().interactable = false; // Disable the pause button.
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game.
    }

    // Game pause logic.
    private bool isPaused = false;
    string pauseText;

    private void Gamepause()
    {
        if (isPaused)
        {
            // Game is already paused, resume the game.
            Time.timeScale = 1.0f; // Resume time flow.
            isPaused = false;
            pauseText = "Pause";
        }
        else
        {
            // Game is not paused, pause the game.
            Time.timeScale = 0.0f; // Pause time flow.
            isPaused = true;
            pauseText = "Continue";
        }

        ui_pause.transform.GetChild(0).GetComponent<Text>().text = pauseText; // Update the pause button text.
    }
}
