using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using static FactoryManager;


public class FactoryManagerTests
{
    [Test]
    public void TestGetRunWay()
    {
        FactoryManager factoryManager = new GameObject().AddComponent<FactoryManager>();
        
        Transform runWay1 = factoryManager.GetRunWay();
        Transform runWay2 = factoryManager.GetRunWay();
        Transform runWay3 = factoryManager.GetRunWay();
        
        // Ensure that runWay1, runWay2, and runWay3 are not null
        Assert.IsNotNull(runWay1);
        Assert.IsNotNull(runWay2);
        Assert.IsNotNull(runWay3);
        
        // Ensure that the returned runways are child objects of factoryManager
        Assert.IsTrue(runWay1.parent == factoryManager.transform);
        Assert.IsTrue(runWay2.parent == factoryManager.transform);
        Assert.IsTrue(runWay3.parent == factoryManager.transform);
    }

    [Test]
    public void TestGetObjectType()
    {
        FactoryManager factoryManager = new GameObject().AddComponent<FactoryManager>();
        
        Transform objectType1 = factoryManager.GetObjectType();
        Transform objectType2 = factoryManager.GetObjectType();
        Transform objectType3 = factoryManager.GetObjectType();
        
        // Ensure that objectType1, objectType2, and objectType3 are not null
        Assert.IsNotNull(objectType1);
        Assert.IsNotNull(objectType2);
        Assert.IsNotNull(objectType3);
        
        // Ensure that the returned object types are one of the specified objects
        Assert.IsTrue(objectType1 == factoryManager._coin || objectType1 == factoryManager._obstacle || 
                      objectType1 == factoryManager._potion || objectType1 == factoryManager._magnet);
        
        Assert.IsTrue(objectType2 == factoryManager._coin || objectType2 == factoryManager._obstacle || 
                      objectType2 == factoryManager._potion || objectType2 == factoryManager._magnet);
        
        Assert.IsTrue(objectType3 == factoryManager._coin || objectType3 == factoryManager._obstacle || 
                      objectType3 == factoryManager._potion || objectType3 == factoryManager._magnet);
    }

    [Test]
    public void TestGenerateRandomFloatWithStep()
    {
        FactoryManager factoryManager = new GameObject().AddComponent<FactoryManager>();
        
        float minValue = 20f;
        float maxValue = 1000f;
        float step = 2f;

        float randomValue = factoryManager.GenerateRandomFloatWithStep(minValue, maxValue, step);

        // Ensure that the generated random value is within the specified range and follows the step
        Assert.GreaterOrEqual(randomValue, minValue);
        Assert.LessOrEqual(randomValue, maxValue);
        Assert.IsTrue(Mathf.Approximately(randomValue % step, 0f));
    }
}
