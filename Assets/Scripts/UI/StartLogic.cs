using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject _start; // Reference to the Start button in the UI.
    [SerializeField]
    private GameObject _rule; // Reference to the Rule button in the UI.
    [SerializeField]
    private GameObject _background; // Reference to the Background button in the UI.
    [SerializeField]
    private List<GameObject> _closes = new List<GameObject>(); // List of buttons to close UI panels.
    [SerializeField]
    private GameObject _sound; // Reference to the sound button in the UI.

    bool isOpen = false; // Flag to track the state of sound (open or closed).

    private void Start()
    {
        // Add a click listener to the "Start" button.
        _start.GetComponent<Button>().onClick.AddListener(() =>
        {
            // Load the "MainScene" when the button is clicked and prevent the AudioSource from being destroyed on load.
            SceneManager.LoadScene("MainScene");
            DontDestroyOnLoad(FindObjectOfType<AudioSource>().gameObject);
        });

        // Add a click listener to the "Rule" button.
        _rule.GetComponent<Button>().onClick.AddListener(() =>
        {
            // Show the "RulePanel" when the button is clicked.
            transform.Find("RulePanel").gameObject.SetActive(true);
        });

        // Add a click listener to the "Background" button.
        _background.GetComponent<Button>().onClick.AddListener(() =>
        {
            // Show the "BackgroundPanel" when the button is clicked.
            transform.Find("BackgroundPanel").gameObject.SetActive(true);
        });

        // Add click listeners to each close button in the list.
        foreach (GameObject item in _closes)
        {
            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                // Close the parent panel of the clicked button.
                item.transform.parent.gameObject.SetActive(false);
            });
        }

        // Add a click listener to the "Sound" button to toggle audio playback.
        _sound.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (isOpen)
            {
                // Pause the AudioSource when it is open.
                FindObjectOfType<AudioSource>().Pause();
                isOpen = false;
            }
            else
            {
                // Play the AudioSource when it is closed.
                FindObjectOfType<AudioSource>().Play();
                isOpen = true;
            }
        });
    }
}
