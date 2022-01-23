using System;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.DataStructer;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public class MainScreenUIPanel : MonoBehaviour
    {
    #region Private Variables

        [Inject]
        private GeneralPlayerData generalPlayerData;

        [Inject]
        private Setting setting;

        [SerializeField]
        private Image endingScreen;

        [SerializeField]
        private List<PlayerUIPanel> playerUIPanels;

    #endregion

    #region Public Methods

        public void GameOver(string deadPlayerDataId)
        {
            var isDemonWin   = deadPlayerDataId.Equals("Angel");
            var endingSprite = isDemonWin ? setting.demonWin : setting.angelWin;
            endingScreen.sprite = endingSprite;
            endingScreen.gameObject.SetActive(true);
            endingScreen.color = new Color(1 , 1 , 1 , 0);
            endingScreen.DOFade(1 , 2);
            Observable.Timer(TimeSpan.FromSeconds(3))
                      .Subscribe(_ => SceneManager.LoadScene(0)).AddTo(gameObject);
        }

        public void SetPlayerHealth(string playerDataId , float amount)
        {
            var playerUIPanel = playerUIPanels.Find(panel => panel.PlayerDataId.Equals(playerDataId));
            playerUIPanel.SetPlayerHealth(amount);
        }

    #endregion

    #region Private Methods

        private void Awake()
        {
            var maxHealth = generalPlayerData.MaxHealth;
            foreach (var playerUIPanel in playerUIPanels) playerUIPanel.SetMaxAmount(maxHealth);
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Setting
        {
        #region Public Variables

            public Sprite angelWin;
            public Sprite demonWin;

        #endregion
        }

    #endregion
    }
}