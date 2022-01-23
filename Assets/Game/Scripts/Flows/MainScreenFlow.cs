using System;
using AutoBot.Scripts.Utilities.Extensions;
using Game.Scripts.Calculator;
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
            playerSpawner.Spawn("Demon");
            playerSpawner.Spawn("Angel");
            var allLampInstances = lampInstanceRegistry.GetAllInstances();
            allLampInstances.Shuffle();
        }

        public void Tick()
        {
            if (gameOver) return;

            HurtAllPlayer();
        }

        public void WhenLightInteractionTriggered(string playerDataId , string lightDataId)
        {
            qteSpawner.Spawn(playerDataId , lightDataId);
        }

        public void WhenPlayerDead(string playerDataId)
        {
            if (gameOver == false) gameOver = true;
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

            var lamp1 = lampInstanceRegistry.GetAllInstances();
            // allLampInstances[0];
            // lamp1.SetOwner(playerDataId);
            // if (playerDataId.Equals("Angel")) { }
            // else { }

            // var lamp2 = allLampInstances[1];
            // var lamp4 = allLampInstances[2];
            // var lamp4 = allLampInstances[3];

            // lampRegistry.AddLampCount(playerDataId , lamp);
            // lampRegistry.AddLampCount(playerDataId);
        }

        /// <summary>
        ///     show the qte Panel on the player's top
        /// </summary>
        /// <param name="playerDataId"></param>
        /// <param name="qteDataId"></param>
        public void WhenQTESpawned(string playerDataId , string qteDataId)
        {
            if (qteDataId.Equals("0"))
            {
                var qteKeyCode = KeyCode.E;
                qtePresenter.ShowQte(playerDataId , qteKeyCode);
                qteDetector.Register(playerDataId , qteKeyCode);
            }
        }

        public void WhenQTESucceed(string succeedPlayerDataId)
        {
            qtePresenter.HideQte(succeedPlayerDataId);
            lampRegistry.AddLampCount(succeedPlayerDataId);
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