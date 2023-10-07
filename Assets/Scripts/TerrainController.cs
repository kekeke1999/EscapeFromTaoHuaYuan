using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainController : MonoBehaviour
{
    [SerializeField]
    private float speed; // Speed at which the terrain moves.

    private void Update()
    {
        // Check if the terrain has moved too far in the negative Z-axis direction.
        if (transform.position.z < -1000)
        {
            // Reset the terrain's position to appear at a new position in the positive Z-axis direction.
            transform.position = new Vector3(0, 0, 1000);
        }
    }

    private void LateUpdate()
    {
        // Move the terrain backward (in the negative Z-axis direction) at a constant speed.
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
