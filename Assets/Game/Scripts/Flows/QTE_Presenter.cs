using Game.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Flows
{
    public class QTE_Presenter
    {
    #region Private Variables

        [Inject]
        private PlayerRegistry playerRegistry;

    #endregion

    #region Public Methods

        public void HideQte(string playerDataId)
        {
            var playerController = playerRegistry.GetPlayerController(playerDataId);
            playerController.SetMovement(true);
            var qtePanel = playerController.GetQtePanel();
            qtePanel.Hide();
        }

        public void ShowQte(string playerDataId , KeyCode keyCode)
        {
            var playerController = playerRegistry.GetPlayerController(playerDataId);
            playerController.SetMovement(false);
            var qtePanel = playerController.GetQtePanel();
            qtePanel.Show(keyCode);
        }

    #endregion
    }
}