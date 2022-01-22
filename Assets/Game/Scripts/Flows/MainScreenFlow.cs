using Game.Scripts.QTE;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Flows
{
    public class MainScreenFlow
    {
    #region Private Variables

        [Inject]
        private QTE_Presenter qtePresenter;

        [Inject]
        private QteDetector qteDetector;

        [Inject]
        private QTESpawner qteSpawner;

    #endregion

    #region Public Methods

        public void WhenLightInteractionTriggered(string playerDataId , string lightDataId)
        {
            qteSpawner.Spawn(playerDataId , lightDataId);
        }

        public void WhenQTESpawned(string playerDataId , string qteDataId)
        {
            if (qteDataId.Equals("0"))
            {
                var qteKeyCode = KeyCode.E;
                qtePresenter.ShowQTE(playerDataId , qteKeyCode);
                qteDetector.Register(playerDataId , qteKeyCode);
            }
        }

        public void WhenQTESucceed()
        {
            qtePresenter.HideQTE();
        }

    #endregion
    }
}