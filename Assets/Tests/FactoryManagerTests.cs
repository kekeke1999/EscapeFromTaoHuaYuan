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
        new GameObject("RunWay0").transform.SetParent(_gameObject.transform);
        new GameObject("RunWay1").transform.SetParent(_gameObject.transform);
        new GameObject("RunWay2").transform.SetParent(_gameObject.transform);
        new GameObject("RunWay3").transform.SetParent(_gameObject.transform);
        new GameObject("RunWay4").transform.SetParent(_gameObject.transform);
        new GameObject("RunWay5").transform.SetParent(_gameObject.transform);
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
        Transform objType = _factoryManager.GetRandomObjectType(FactoryManager.ObjectSpawnMean, FactoryManager.ObjectSpawnStandardDeviation);
        
        Assert.IsTrue(objType == _factoryManager.getCoin() || objType == _factoryManager.getObstacle() || objType == _factoryManager.getPotion() || objType == _factoryManager.getMagnet());
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator RunWayIsExpected()
    {
        Transform runWay = _factoryManager.GetRandomRunWay(FactoryManager.RunWayMean, FactoryManager.RunWayStandardDeviation);
        
        Transform left = _factoryManager.transform.GetChild(3);
        Transform center = _factoryManager.transform.GetChild(5);
        Transform right = _factoryManager.transform.GetChild(4);
        
        Assert.IsTrue(runWay == left || runWay == center || runWay == right);
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator RandomFloatIsWithinRangeAndOnStep()
    {
        float generatedValue = _factoryManager.GenerateRandomFloatWithStep(10f, 50f, 5f);
        Assert.IsTrue(generatedValue >= 10f && generatedValue <= 50f);
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator RandomValueIsWithinRange()
    {
        float generatedValue = _factoryManager.GenerateRandomValue(10f, 5f);
        Assert.IsTrue(generatedValue >= -5f && generatedValue <= 25f);
        
        yield return null;
    }
}
