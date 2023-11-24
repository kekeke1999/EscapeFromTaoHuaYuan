// As a parkour game, the terrain needs to continuously loop to create an infinitely long path.
// Basic Logic:
// By checking the position in Update(), the script ensures that the terrain does not move backward indefinitely, but loops back after reaching a certain distance.
// LateUpdate() is used to achieve continuous and smooth movement of the terrain, as it executes after all Update methods are called, ensuring all game logic and position updates have been completed.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainController : MonoBehaviour
{
    [SerializeField]
    private float speed; // Speed at which the terrain moves.

    public float getSpeed() {
        return speed;
    }

    public void setSpeed(float _speed) {
        speed = _speed;
    }

    public void Update()
    {
        // Check if the terrain has moved too far in the negative Z-axis direction.
        if (transform.position.z < -1000)
        {
            // Reset the terrain's position to appear at a new position in the positive Z-axis direction.
            transform.position = new Vector3(0, 0, 1000);
        }
    }

    public void LateUpdate()
    {
        // Move the terrain backward (in the negative Z-axis direction) at a constant speed.
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
