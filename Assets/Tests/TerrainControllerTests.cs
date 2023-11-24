using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class TerrainControllerTests
{
    private TerrainController _terrainController;
    private GameObject _terrainGameObject;

    [SetUp]
    public void SetUp()
    {
        // Initialize a new GameObject and add the TerrainController component to it for testing.
        _terrainGameObject = new GameObject("Terrain");
        _terrainController = _terrainGameObject.AddComponent<TerrainController>();
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the GameObject created during the test to prevent memory leaks or test interference.
        Object.DestroyImmediate(_terrainGameObject);
    }

    [Test]
    public void Speed_SetAndGet_ReturnsCorrectValue()
    {
        // Define the expected speed value for testing.
        float expectedSpeed = 5f;

        // Set the speed on the TerrainController and then retrieve it.
        _terrainController.setSpeed(expectedSpeed);
        float actualSpeed = _terrainController.getSpeed();

        // Verify that the set speed is correctly retrieved, ensuring the getter and setter work as expected.
        Assert.AreEqual(expectedSpeed, actualSpeed);
    }

    [Test]
    public void TerrainPosition_ResetsCorrectly_WhenMovedTooFar()
    {
        // Set a high speed for the test and move the terrain beyond the reset limit.
        _terrainController.setSpeed(100f); // Set a high speed for the test
        _terrainGameObject.transform.position = new Vector3(0, 0, -1001); // Set the terrain beyond the reset limit

        // Trigger the Update method, which should reset the terrain's position.
        _terrainController.Update();

        // Verify that the terrain's position is reset correctly when it moves too far in the negative Z-axis direction.
        Assert.AreEqual(new Vector3(0, 0, 1000), _terrainGameObject.transform.position);
    }

}
