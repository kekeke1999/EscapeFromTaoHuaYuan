using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public const int NumberOfObjectsToCreate = 150;
    public const float Step = 2.0f;

    [SerializeField]
    private Transform _coin; // Prefab for coins.
    [SerializeField]
    private Transform _obstacle; // Prefab for obstacles.
    [SerializeField]
    private Transform _potion; // Prefab for potions.
    [SerializeField]
    private Transform _magnet; // Prefab for magnets.


    public void setCoin(Transform coin) {
        _coin = coin;
    }

    public void setPotion(Transform potion) {
        _potion = potion;
    }

    public void setObstacle(Transform obstacle) {
        _obstacle = obstacle;
    }

    public void setMagnet(Transform magnet) {
        _magnet = magnet;
    }

    public Transform getCoin() {
        return _coin;
    }

    public Transform getPotion() {
        return _potion;
    }

    public Transform getObstacle() {
        return _obstacle;
    }

    public Transform getMagnet() {
        return _magnet;
    }

    // Start is called before the first frame update. It initializes the game objects.
    public void Start()
    {
        for (int i = 0; i < NumberOfObjectsToCreate; i++)
        {
            Transform objectType = GetRandomObjectType(); // Choose a random object type.
            Transform runWay = GetRandomRunWay(); // Select a random runway for placement.
            Transform objectInRunway = Instantiate(objectType, runWay); // Instantiate the object.
            // Position the object at a random distance on the runway.
            objectInRunway.localPosition = new Vector3(0, transform.position.y, GenerateRandomFloatWithStep(20f, 1000f, Step));
        }
    }

    // Selects a random runway from the available ones.
    public Transform GetRandomRunWay()
    {
        // transform.GetChild(3) represents the left runway, transform.GetChild(4) represents the middle runway, transform.GetChild(5) represents the right runway
        Transform[] runways = new Transform[] { transform.GetChild(3), transform.GetChild(4), transform.GetChild(5) };
        // Return a randomly selected runway.
        return runways[Random.Range(0, runways.Length)];
    }


    // Use Weighted Random Sampling.
     // Selects a random object type with weighted probabilities.
    public Transform GetRandomObjectType()
    {
        // Define weights for each object type.
        float totalWeight = 6f + 3f + 0.5f + 0.5f;
        float randomValue = Random.Range(0, totalWeight);
        // Determine the object type based on the generated random value.
        if (randomValue < 6) return _coin; // Coin has the highest probability.
        else if (randomValue < 9) return _obstacle; // Obstacle has the second-highest probability.
        else if (randomValue < 9.5) return _magnet; // Magnet has lower probability.
        else return _potion; // Potion has the same probability as the magnet.
    }



    // Generate a random floating-point value with a specified step.
    public float GenerateRandomFloatWithStep(float minValue, float maxValue, float step)
    {
        // Calculate the number of steps within the range.
        float stepRange = (maxValue - minValue) / step;

        // Generate a random step within the step range.
        float randomStep = Random.Range(0, stepRange + 1);

        // Calculate a random floating-point value based on the step.
        return minValue + randomStep * step;
    }
}
