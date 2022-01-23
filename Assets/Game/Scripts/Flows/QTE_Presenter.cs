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

        public void HideQTE()
        {
            // refenerce.QTEPanel.Hide();
        }

        public void ShowQte(string playerDataId , KeyCode keyCode)
        {
            var playerController = playerRegistry.GetPlayerController(playerDataId);
            var qtePanel         = playerController.GetQtePanel();
            qtePanel.Show(keyCode);
        }

    #endregion
    }
}