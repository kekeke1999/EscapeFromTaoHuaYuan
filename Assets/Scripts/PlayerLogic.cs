using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLogic : MonoBehaviour
{
    public float health; // Player's health value.
    private float coinCount = 0; // Number of collected coins.

    private Coroutine magnetCoroutine; // Coroutine reference for the magnet effect.

    UIMain uIMain; // Reference to the UIMain script.

    public void Start()
    {
        uIMain = FindObjectOfType<UIMain>(); // Find and reference the UIMain script.
    }

    float t = 0; // Timer for magnet effect duration.
    public void Update()
    {
        if (magnetCoroutine != null)
        {
            t += Time.deltaTime;

            // If the effect of magnet has been active for more than 3 seconds, stop it.
            if (t > 3)
            {
                StopCoroutine(magnetCoroutine);
                magnetCoroutine = null;
                t = 0;

                // Reset the UI property text.
                uIMain.ui_prop.text = "None";
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                SetCoinValue(other.transform.parent.parent.gameObject);
                break;
            case "Obstacle":
                SetHealth(other.transform.parent.gameObject, -10);
                break;
            case "Potion":
                SetHealth(other.transform.parent.parent.gameObject, 5);
                break;
            case "Magnet":
                DrawCoin(other.transform.parent.parent.gameObject);
                break;
        }
    }

    // Collect a coin then update the UI coin count.
    public void SetCoinValue(GameObject obj)
    {
        coinCount += 1;
        Destroy(obj);
        uIMain.ui_coin.text = coinCount.ToString();
    }

    // Handle stepping on an obstacle, collect a potion, and update the UI health.
    public void SetHealth(GameObject obj, float value)
    {
        health += value;

        // Ensure that health value remains within the range [0, 100].
        if (health > 100) health = 100;
        if (health < 0) health = 0;

        Destroy(obj);
        uIMain.ui_health.text = health.ToString();

        // Update the UI property text to "Potion."
        uIMain.ui_prop.text = "Potion";
    }

    // Collect a magnet effect and initiate the magnet coroutine.
    public void DrawCoin(GameObject obj)
    {
        magnetCoroutine = StartCoroutine(MagnetCoins());

        Destroy(obj);

        // Update the UI property text to "Magnet."
        uIMain.ui_prop.text = "Magnet";
    }

    // Coroutine for magnet effect.
    public IEnumerator MagnetCoins()
    {
        while (true)
        {
            // Find nearby colliders within a 50 unit radius.
            Collider[] colliders = Physics.OverlapSphere(transform.position, 50f);

            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Coin"))
                {
                    // Move the parent object of the coin towards the player.
                    col.transform.parent.parent.position = Vector3.Lerp(col.transform.parent.parent.position, transform.position, Time.deltaTime * 15f) + new Vector3(0, -0.5f, 0);
                }
            }

            yield return null; // Wait for the next frame.
        }
    }
}
