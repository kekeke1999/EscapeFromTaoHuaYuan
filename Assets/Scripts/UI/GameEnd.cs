using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private Button[] Btns = new Button[2]; // Array to store two buttons.
    public Text count; // Reference to the UI text element for displaying a count.

    UIMain uIMain; // Reference to the UIMain script.

    private void Start()
    {
        // Get a reference to the UIMain script from the parent object.
        uIMain = transform.parent.GetComponent<UIMain>();

        // Get all buttons that are children of this GameObject.
        Btns = transform.GetComponentsInChildren<Button>();

        // Add a click listener to the button named "Restart".
        Btns[0].onClick.AddListener(() =>
        {
            // Load the "MainScene" when the button is clicked.
            SceneManager.LoadScene("MainScene");
        });

        // Add a click listener to the button named "Back to Main Menu".
        Btns[1].onClick.AddListener(() =>
        {
            // Load the "StartScene" when the button is clicked.
            SceneManager.LoadScene("StartScene");
        });

        // Call the GetCoinCount function to update the displayed count.
        GetCoinCount();
    }

    private void GetCoinCount()
    {
        // Set the text of the "CoinCount" UI element to match the coin count from the UIMain script.
        count.text = uIMain.ui_coin.text;
    }
}
