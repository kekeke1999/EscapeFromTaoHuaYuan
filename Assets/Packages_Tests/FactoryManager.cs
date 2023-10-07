using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    [SerializeField]
    public Transform _coin; // Prefab for coins.
    [SerializeField]
    public Transform _obstacle; // Prefab for obstacles.
    [SerializeField]
    public Transform _potion; // Prefab for potions.
    [SerializeField]
    public Transform _magnet; // Prefab for magnets.

    public void Start()
    {
        BuildObject(); // Generate game objects.
    }

    // Generate objects (coins, obstacles, potions, magnets).
    public void BuildObject()
    {
        Transform tempObj;
        Transform objType;
        Transform tempParent;

        for (int i = 0; i < 150; i++)
        {
            objType = GetObjectType(); // Determine the type of object to create (coin, obstacle, potion, or magnet).
            tempParent = GetRunWay(); // Choose a lane (left, center, or right).

            tempObj = Instantiate(objType, tempParent); // Create a new object of the chosen type.
            tempObj.localPosition = new Vector3(0, transform.position.y, GenerateRandomFloatWithStep(20f, 1000f, 2f)); // Randomize the object's position within the lane.
        }
    }

    // Get a lane (left, center, or right).
    public Transform GetRunWay()
    {
        float tempVal;
        Transform parent;
        tempVal = Random.Range(0, 0.9f);

        if (tempVal < 0.3f)
        {
            parent = transform.GetChild(3); // Left lane.
        }
        else if (tempVal > 0.6)
        {
            parent = transform.GetChild(4); // Right lane.
        }
        else
        {
            parent = transform.GetChild(5); // Center lane.
        }
        return parent;
    }

    // Get a random object type (coin, obstacle, potion, or magnet).
    public Transform GetObjectType()
    {
        float tempVal = Random.Range(1f, 10f);

        if (tempVal < 6)
        {
            return _coin; // Coin prefab.
        }
        else if (tempVal > 6 && tempVal < 9)
        {
            return _obstacle; // Obstacle prefab.
        }
        else if (tempVal > 9 && tempVal < 9.5f)
        {
            return _magnet; // Magnet prefab.
        }
        else
        {
            return _potion; // Potion prefab.
        }
    }

    // Generate a random floating-point value with a specified step.
    public float GenerateRandomFloatWithStep(float minValue, float maxValue, float step)
    {
        // Calculate the number of steps within the range.
        float stepRange = (maxValue - minValue) / step;

        // Generate a random step within the step range.
        float randomStep = UnityEngine.Random.Range(0, stepRange + 1);

        // Calculate a random floating-point value based on the step.
        float randomValue = minValue + randomStep * step;

        return randomValue;
    }
}
