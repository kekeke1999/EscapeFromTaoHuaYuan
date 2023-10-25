using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class PlayerLogicTests
{
    // private GameObject _playerGameObject;
    // private PlayerLogic _playerLogic;
    // private GameObject _uiMainGameObject;
    // private UIMain _uiMain;

    // [SetUp]
    // public void Setup()
    // {
    //     _playerGameObject = new GameObject("Player");
    //     _playerLogic = _playerGameObject.AddComponent<PlayerLogic>();
    //     _uiMainGameObject = new GameObject("UIMain");
    //     _uiMain = _uiMainGameObject.AddComponent<UIMain>();
    // }

    // [TearDown]
    // public void TearDown()
    // {
    //     Object.DestroyImmediate(_playerGameObject);
    //     Object.DestroyImmediate(_uiMainGameObject);
    // }

    // [Test]
    // public void CoinCollectionUpdatesUICorrectly()
    // {
    //     GameObject coinObject = new GameObject("CoinParentParent");
    //     new GameObject("CoinParent").AddComponent<BoxCollider>().tag = "Coin";

    //     _playerLogic.OnTriggerEnter(coinObject.GetComponentInChildren<BoxCollider>());

    //     Assert.AreEqual("1", _uiMain.ui_coin.text);
    //     Assert.IsNull(coinObject.gameObject);
    // }

    // [Test]
    // public void ObstacleReducesHealthCorrectly()
    // {
    //     _playerLogic.health = 50;
    //     GameObject obstacleObject = new GameObject("ObstacleParent");
    //     new GameObject("Obstacle").AddComponent<BoxCollider>().tag = "Obstacle";

    //     _playerLogic.OnTriggerEnter(obstacleObject.GetComponentInChildren<BoxCollider>());

    //     Assert.AreEqual("40", _uiMain.ui_health.text);
    //     Assert.AreEqual("Potion", _uiMain.ui_prop.text);
    //     Assert.IsNull(obstacleObject.gameObject);
    // }

    // [Test]
    // public void PotionIncreasesHealthCorrectly()
    // {
    //     _playerLogic.health = 50;
    //     GameObject potionObject = new GameObject("PotionParentParent");
    //     new GameObject("PotionParent").AddComponent<BoxCollider>().tag = "Potion";

    //     _playerLogic.OnTriggerEnter(potionObject.GetComponentInChildren<BoxCollider>());

    //     Assert.AreEqual("55", _uiMain.ui_health.text);
    //     Assert.AreEqual("Potion", _uiMain.ui_prop.text);
    //     Assert.IsNull(potionObject.gameObject);
    // }

    // [Test]
    // public void HealthDoesNotExceedMaxValue()
    // {
    //     _playerLogic.health = 98;
    //     GameObject potionObject = new GameObject("PotionParentParent");
    //     new GameObject("PotionParent").AddComponent<BoxCollider>().tag = "Potion";

    //     _playerLogic.OnTriggerEnter(potionObject.GetComponentInChildren<BoxCollider>());

    //     Assert.AreEqual("100", _uiMain.ui_health.text);
    // }

    // [Test]
    // public void HealthDoesNotDropBelowZero()
    // {
    //     _playerLogic.health = 8;
    //     GameObject obstacleObject = new GameObject("ObstacleParent");
    //     new GameObject("Obstacle").AddComponent<BoxCollider>().tag = "Obstacle";

    //     _playerLogic.OnTriggerEnter(obstacleObject.GetComponentInChildren<BoxCollider>());

    //     Assert.AreEqual("0", _uiMain.ui_health.text);
    // }

    // [UnityTest]
    // public IEnumerator MagnetEffectDrawsCoins()
    // {
    //     GameObject magnetObject = new GameObject("MagnetParentParent");
    //     new GameObject("MagnetParent").AddComponent<BoxCollider>().tag = "Magnet";

    //     GameObject coinObject = new GameObject("CoinParentParent");
    //     coinObject.transform.position = new Vector3(55, 0, 0);
    //     new GameObject("CoinParent").AddComponent<BoxCollider>().tag = "Coin";

    //     _playerLogic.OnTriggerEnter(magnetObject.GetComponentInChildren<BoxCollider>());
    //     yield return new WaitForSeconds(0.5f); // Give it some time for the coin to move closer.

    //     Assert.Less(Vector3.Distance(_playerGameObject.transform.position, coinObject.transform.position), 55);
    // }
}
