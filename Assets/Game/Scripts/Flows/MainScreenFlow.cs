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

        public void WhenQTESpawned(string spawnedQteDataId)
        {
            Debug.Log($"{spawnedQteDataId}");
            if (spawnedQteDataId.Equals("0"))
            {
                var qteKeyCode = KeyCode.E;
                qtePresenter.ShowQTE(qteKeyCode);
                qteDetector.Register(qteKeyCode);
            }
        }

        public void WhenQTESucceed()
        {
            qtePresenter.HideQTE();
        }

    #endregion
    }
}