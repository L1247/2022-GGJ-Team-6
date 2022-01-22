using Game.Scripts.DataStructer;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerPresenter
    {
    #region Private Variables

        [Inject]
        private ActorDataOverview actorDataOverview;

    #endregion

    #region Public Methods

        public void ShowPlayer(string playerDataId , GameObject playerInstance)
        {
            var actorData        = actorDataOverview.GetActorData(playerDataId);
            var playerController = playerInstance.GetComponent<PlayerController>();
            playerController.Init(actorData);
        }

    #endregion
    }
}