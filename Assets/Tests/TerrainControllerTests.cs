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
        _terrainGameObject = new GameObject("Terrain");
        _terrainController = _terrainGameObject.AddComponent<TerrainController>();
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup
        Object.DestroyImmediate(_terrainGameObject);
    }

    [Test]
    public void Speed_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        float expectedSpeed = 5f;

        // Act
        _terrainController.setSpeed(expectedSpeed);
        float actualSpeed = _terrainController.getSpeed();

        // Assert
        Assert.AreEqual(expectedSpeed, actualSpeed);
    }

    [Test]
    public void TerrainPosition_ResetsCorrectly_WhenMovedTooFar()
    {
        // Arrange
        _terrainController.setSpeed(100f); // Set a high speed for the test
        _terrainGameObject.transform.position = new Vector3(0, 0, -1001); // Set the terrain beyond the reset limit

        // Act
        _terrainController.Update();

        // Assert
        Assert.AreEqual(new Vector3(0, 0, 1000), _terrainGameObject.transform.position);
    }

}
