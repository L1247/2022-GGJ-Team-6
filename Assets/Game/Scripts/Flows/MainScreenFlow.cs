using System;
using AutoBot.Scripts.Utilities.Extensions;
using Game.Scripts.Calculator;
using Game.Scripts.DataStructer;
using Game.Scripts.Lamp;
using Game.Scripts.Player;
using Game.Scripts.QTE;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Flows
{
    public class MainScreenFlow : IInitializable , ITickable
    {
    #region Private Variables

        private bool gameOver;

        [Inject]
        private DiContainer container;

        [Inject]
        private HealthCalculator healthCalculator;

        [Inject]
        private LampCalculator lampCalculator;

        [Inject]
        private LampCalculatorData lampCalculatorData;

        [Inject]
        private LampInstanceRegistry lampInstanceRegistry;

        [Inject]
        private LampRegistry lampRegistry;

        [Inject]
        private MainScreenUIPanel mainScreenUIPanel;

        [Inject]
        private PlayerPresenter playerPresenter;

        [Inject]
        private PlayerRegistry playerRegistry;

        [Inject]
        private PlayerSpawner playerSpawner;

        [Inject]
        private QTE_Presenter qtePresenter;

        [Inject]
        private QteDetector qteDetector;

        [Inject]
        private QTESpawner qteSpawner;

        [Inject]
        private Setting setting;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            var allLampInstances = lampInstanceRegistry.GetAllInstances();
            allLampInstances.Shuffle();
            playerSpawner.Spawn("Demon");
            playerSpawner.Spawn("Angel");
            Application.targetFrameRate = 60;
        }

        public void Tick()
        {
            if (gameOver) return;

            HurtAllPlayer();
        }

        public void WhenLightInteractionTriggered(string playerDataId , string lampDataId)
        {
            var qteDataId = playerDataId.Equals("Angel") ? "0" : "1";
            var lamp      = lampInstanceRegistry.GetLamp(lampDataId);
            var isOwner   = lamp.Owner.Equals(playerDataId);
            if (isOwner) return;
            qteSpawner.Spawn(playerDataId , qteDataId , lampDataId);
        }

        public void WhenPlayerDead(string playerDataId)
        {
            if (gameOver == false)
            {
                gameOver = true;
                mainScreenUIPanel.GameOver(playerDataId);
            }
        }

        public void WhenPlayerHealthChanged(string dataId , float currentHealth)
        {
            mainScreenUIPanel.SetPlayerHealth(dataId , currentHealth);
        }

        public void WhenPlayerSpawned(string playerDataId)
        {
            var playerInstance   = container.InstantiatePrefab(setting.PlayerPrefab);
            var playerController = playerInstance.GetComponent<PlayerController>();
            playerRegistry.Register(playerDataId , playerController);
            playerPresenter.ShowPlayer(playerDataId);

            var allLampInstances = lampInstanceRegistry.GetAllInstances();
            var lampCount        = lampCalculatorData.LampCount;
            var countPerPlayer   = lampCount / 2;
            if (playerDataId.Equals("Angel"))
                for (var i = 0 ; i < countPerPlayer ; i++)
                {
                    var lamp = allLampInstances[i];
                    lamp.SetOwner(playerDataId);
                }
            else
                for (var i = lampCount - 1 ; i >= 0 ; i--)
                {
                    var lamp = allLampInstances[i];
                    lamp.SetOwner(playerDataId);
                }

            lampRegistry.AddLampCount(playerDataId);
            lampRegistry.AddLampCount(playerDataId);
        }

        /// <summary>
        ///     show the qte Panel on the player's top
        /// </summary>
        /// <param name="playerDataId"></param>
        /// <param name="qteDataId"></param>
        /// <param name="lampDataId"></param>
        public void WhenQTESpawned(string playerDataId , string qteDataId , string lampDataId)
        {
            var isE        = qteDataId.Equals("0");
            var qteKeyCode = isE ? KeyCode.E : KeyCode.Keypad1;
            qtePresenter.ShowQte(playerDataId , qteKeyCode);
            qteDetector.Register(playerDataId , qteKeyCode , lampDataId);
        }

        public void WhenQTESucceed(string succeedPlayerDataId , string lampDataId)
        {
            var subPlayerDataId = succeedPlayerDataId.Equals("Angel") ? "Demon" : "Angel";
            var addPlayerDataId = succeedPlayerDataId.Equals("Angel") ? "Angel" : "Demon";
            qtePresenter.HideQte(succeedPlayerDataId);
            var lamp = lampInstanceRegistry.GetLamp(lampDataId);
            lamp.SetOwner(succeedPlayerDataId);
            lampRegistry.AddLampCount(addPlayerDataId);
            lampRegistry.SubLampCount(subPlayerDataId);
        }

    #endregion

    #region Private Methods

        private void HurtAllPlayer()
        {
            foreach (var playerController in playerRegistry.GetAllPlayerController())
            {
                if (playerController.IsDead) continue;
                var dataId              = playerController.GetDataId();
                var lampCount           = lampRegistry.GetLampCount(dataId);
                var lampMultiplyByCount = lampCalculator.GetLampMultiplyByCount(lampCount);
                var damage              = healthCalculator.GetDamage(lampMultiplyByCount);
                playerController.TakeDamage(damage);
            }
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Setting
        {
        #region Public Variables

            public GameObject PlayerPrefab;

        #endregion
        }

    #endregion
    }
}