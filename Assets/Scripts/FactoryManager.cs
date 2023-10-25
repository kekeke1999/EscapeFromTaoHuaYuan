using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public const int NumberOfObjectsToCreate = 150;
    public const float ObjectSpawnMean = 5.5f;
    public const float ObjectSpawnStandardDeviation = 2.0f;
    public const float RunWayMean = 0.5f;
    public const float RunWayStandardDeviation = 0.2f;
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

    public void Start()
    {
        for (int i = 0; i < NumberOfObjectsToCreate; i++)
        {
            Transform objType = GetRandomObjectType(ObjectSpawnMean, ObjectSpawnStandardDeviation);
            Transform runWay = GetRandomRunWay(RunWayMean, RunWayStandardDeviation);
            Transform obj = Instantiate(objType, runWay);
            obj.localPosition = new Vector3(0, transform.position.y, GenerateRandomFloatWithStep(20f, 1000f, 2f));
        }
    }


    // Get a lane (left, center, or right). 0.5 0.2
    public Transform GetRandomRunWay(float mean, float standardDeviation)
    {
        float randomValue = GenerateRandomValue(mean, standardDeviation);

        Transform[] runWays = new Transform[3] { transform.GetChild(3), transform.GetChild(5), transform.GetChild(4) }; // 左、中、右

        if (randomValue < mean - standardDeviation)
        {
            return runWays[0]; // Left runWay.
        }
        else if (randomValue > mean + standardDeviation)
        {
            return runWays[2]; // Right runWay.
        }
        else
        {
            return runWays[1]; // Center runWay.
        }
    }



    // Get a random object type (coin, obstacle, potion, or magnet). 5.5f 2.0f
    public Transform GetRandomObjectType(float mean, float standardDeviation)
    {

        float randomValue = GenerateRandomValue(mean, standardDeviation);

        if (randomValue < mean - standardDeviation)
            return _coin; // Coin prefab.
        
        if (randomValue < mean + standardDeviation)
            return _obstacle; // Obstacle prefab;
        
        if (randomValue < mean + 1.5f * standardDeviation)
            return _magnet; // Magnet prefab;

        return _potion; // Potion prefab.
    }

    public float GenerateRandomValue(float mean, float standardDeviation)
    {
        return Random.Range(mean - 3 * standardDeviation, mean + 3 * standardDeviation);
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
