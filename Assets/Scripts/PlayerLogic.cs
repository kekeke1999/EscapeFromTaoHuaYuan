//This code outlines the player's behaviour and interactions.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLogic : MonoBehaviour
{
    public float health; // Player's health value.
    private float coinCount = 0; // Number of collected coins.

    private Coroutine magnetCoroutine; // Coroutine variable for managing the magnet effect.

    UIMain uIMain; // Reference to the UIMain script.

    public void Start()
    {
        uIMain = FindObjectOfType<UIMain>(); // Find and reference the UIMain script.
    }

    
    //Update(): Manage the duration of the effect for magnet using a timer (t). 
    //If the effect lasts more than 3 seconds, it stops the coroutine and resets the UI text for the property to "None".
    //Rule: the magnet's effect can only last for 3 seconds!
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


    //OnTriggerEnter(): Handle collisions with various game objects (coins, obstacles, potions, magnets) identified by their tags.
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
    
    
    // SetCoinValue(): Collect a coin then update the UI coin count.
    // Rule: As a parkour game, the player's main task is to avoid obstacles and collect props and coins.
    // When the player collides with a coin, the UI coin count increases by 1.
    public void SetCoinValue(GameObject obj)
    {
        coinCount += 1;
        Destroy(obj);
        uIMain.ui_coin.text = coinCount.ToString();
    }


    // SetHealth(): Handle behaviours related to life value(stepping on an obstacle and collect a potion) and update the UI health.
    // Rule: the initial health value is 100. It will change due to collisions with different items.
    // When the player collides with an obstacle, life value will decrease by 10;
    // When the player collides with a potion, life value will increase by 5. 
    public void SetHealth(GameObject obj, float value)
    {
        health += value;

        // Ensure that health value remains within the range [0, 100].
        if (health > 100) health = 100;
        if (health < 0) health = 0;

        Destroy(obj);
        uIMain.ui_health.text = health.ToString();

        // Update the UI text for "Prop" to "Potion."
        uIMain.ui_prop.text = "Potion";
    }

    // DrawCoin(): Collect a magnet effect and initiate the magnet coroutine.
    // Rule: Magnet is a prop for the player. The effect is to draw the nearby coins.
    public void DrawCoin(GameObject obj)
    {
        magnetCoroutine = StartCoroutine(MagnetCoins());

        Destroy(obj);

        // Update the UI property text to "Magnet."
        uIMain.ui_prop.text = "Magnet";
    }

    // MagnetCoins(): Coroutine for magnet effect.
    // The magnet can finds nearby coin colliders within a 50 unit radius 
    // and move coins towards the player's position.
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
                    // Move the coin's actual position in the scene hierarchy towards the player.
                    // Time.deltaTime * 15f determines the speed of the movement.
                    // + new Vector3(0, -0.5f, 0) adjusts the position of the coin slightly downwards to avoid collisions.
                    col.transform.parent.parent.position = Vector3.Lerp(col.transform.parent.parent.position, transform.position, Time.deltaTime * 15f) + new Vector3(0, -0.5f, 0);
                }
            }

            yield return null; // Wait for the next frame.
        }
    }
}
