using System;
using Game.Scripts.Player;
using Game.Scripts.QTE;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Scripts.Flows
{
    public class MainScreenFlow : IInitializable
    {
    #region Private Variables

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
        }

        public void WhenLightInteractionTriggered(string playerDataId , string lightDataId)
        {
            qteSpawner.Spawn(playerDataId , lightDataId);
        }

        public void WhenPlayerSpawned(string playerDataId)
        {
            var playerInstance   = Object.Instantiate(setting.PlayerPrefab);
            var playerController = playerInstance.GetComponent<PlayerController>();
            playerRegistry.Register(playerDataId , playerController);
            playerPresenter.ShowPlayer(playerDataId);
        }

        public void WhenQTESpawned(string playerDataId , string qteDataId)
        {
            if (qteDataId.Equals("0"))
            {
                var qteKeyCode = KeyCode.E;
                qtePresenter.ShowQte(playerDataId , qteKeyCode);
                qteDetector.Register(playerDataId , qteKeyCode);
            }
        }

        public void WhenQTESucceed()
        {
            qtePresenter.HideQTE();
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