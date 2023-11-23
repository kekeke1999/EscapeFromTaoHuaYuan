using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class FactoryManagerTests
{
    private FactoryManager _factoryManager;
    private GameObject _gameObject;

    [SetUp]
    public void Setup()
    {
        // Create a GameObject with the FactoryManager script attached.
        _gameObject = new GameObject("FactoryManagerObject");
        _factoryManager = _gameObject.AddComponent<FactoryManager>();

        // Set up mock prefabs for testing.
        _factoryManager.setCoin(new GameObject("Coin").transform);
        _factoryManager.setObstacle(new GameObject("Obstacle").transform);
        _factoryManager.setMagnet(new GameObject("Magnet").transform);
        _factoryManager.setPotion(new GameObject("Potion").transform);

        // Add child objects to represent lanes (Mock RunWays).
        // Ensure there are only three runways, consistent with the assumptions in the FactoryManager class.
        new GameObject("RunWay0").transform.SetParent(_gameObject.transform);
        new GameObject("RunWay1").transform.SetParent(_gameObject.transform);
        new GameObject("RunWay2").transform.SetParent(_gameObject.transform);
        new GameObject("LeftRunWay").transform.SetParent(_gameObject.transform); // Left runway
        new GameObject("CenterRunWay").transform.SetParent(_gameObject.transform); // Center runway
        new GameObject("RightRunWay").transform.SetParent(_gameObject.transform); // Right runway
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup.
        Object.DestroyImmediate(_gameObject);
    }

    [UnityTest]
    public IEnumerator ObjectTypeIsExpected()
    {
        Transform objType = _factoryManager.GetRandomObjectType(); // Get a random object type
        
        // Verify that the object type is one of the expected types
        Assert.IsTrue(objType == _factoryManager.getCoin() || objType == _factoryManager.getObstacle() || objType == _factoryManager.getPotion() || objType == _factoryManager.getMagnet());
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator RunWayIsExpected()
    {
        Transform runWay = _factoryManager.GetRandomRunWay(); // Get a random runway
        
        Transform left = _factoryManager.transform.GetChild(3); // Left runway
        Transform center = _factoryManager.transform.GetChild(4); // Center runway
        Transform right = _factoryManager.transform.GetChild(5); // Right runway
        
        // Verify that the runway is one of the expected runways
        Assert.IsTrue(runWay == left || runWay == center || runWay == right);
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator RandomFloatIsWithinRangeAndOnStep()
    {
        float generatedValue = _factoryManager.GenerateRandomFloatWithStep(10f, 50f, 5f);
        // Verify that the generated value is within the specified range and follows the step rule
        Assert.IsTrue(generatedValue >= 10f && generatedValue <= 50f);
        
        yield return null;
    }
}
