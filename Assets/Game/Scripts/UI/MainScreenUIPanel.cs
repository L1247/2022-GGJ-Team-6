using System.Collections.Generic;
using Game.Scripts.DataStructer;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class MainScreenUIPanel : MonoBehaviour
    {
    #region Private Variables

        [Inject]
        private GeneralPlayerData generalPlayerData;

        [SerializeField]
        private List<PlayerUIPanel> playerUIPanels;

    #endregion

    #region Public Methods

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
    }
}