using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class MainScreenUIPanel : MonoBehaviour
    {
    #region Private Variables

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
    }
}